using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private GameObject waypoints;
    //private int currentWaypointIndex = 0;
    private GameObject player; //the player object
    public float speed = 5f; //the speed of the enemy
    private Animator anim;
    private SpriteRenderer sr; //the sprite renderer component
    [SerializeField] private float distanceView = 10f;
    public float bulletForce = 750f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    //public int damage = 40;
    float fireRate = 3f;
    private float nextFire = 0.0f;
    private bool facingLeft = true;
    private float coolDownPeriodInSeconds = 10f;
    private float timeStamp = 0.0f;
    public int ghostBlood = 100;
    public int currentHealth = 100;
    public HealthBar healthBar;
    [SerializeField]private GameObject finishOBJ;
    //SpriteRenderer sprGhost;
    GameObject healthbarOBJ;
    [SerializeField] private GameObject waypointLeft;
    [SerializeField] private GameObject waypointRight;
    void Start()
    {
        //get the sprite renderer component
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        healthbarOBJ = GameObject.Find("GhostHealthBar");
        currentHealth = ghostBlood;
        healthBar.SetMaxHealth(ghostBlood);
    }

    void Update()
    {
        float distance = Vector2.Distance(player.transform.position,
            transform.position);
        if (distance <= distanceView + 5f)
        {
            healthbarOBJ.SetActive(true);
        }
        else
        {
            healthbarOBJ.SetActive(false);
        }
        if (distance <= distanceView)
        {
            //Debug.Log("Chicken Run");
            if ((player.transform.position.y - waypoints.transform.position.y) <= 4f)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                player.transform.position, Time.deltaTime * speed);
                int randomSkill = Random.Range(1, 10);
                if(randomSkill == 2  &&  timeStamp <= Time.time)
                {
                    timeStamp = Time.time + coolDownPeriodInSeconds;
                    anim.SetTrigger("Desappear");
                    Invoke("DisableGhost", 0.3f);
                    Invoke("TeleGhost", 1f);
                }
                else
                {                
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Shoot();
                }
                if (transform.position.x > player.transform.position.x)
                {
                    if (!facingLeft)
                    {
                        Flip();
                    }
                }
                else
                {
                    if (facingLeft)
                    {
                        Flip();
                    }
                }
                }
            }
            else
            {
                anim.SetTrigger("Ghost_Idle");
            }
        }
        else
        {
            anim.SetTrigger("Ghost_Idle");
        }
        if(currentHealth == 0)
        {
            anim.SetTrigger("Hit");
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Invoke("Destroy", 2f);
            finishOBJ.SetActive(true);
        }
    }
    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * bulletForce);
        Destroy(newBullet,4f);
    }
    void Flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(0f, 180f, 0f);
    }
    void DisableGhost()
    {
        gameObject.SetActive(false);
        
    }

    void TeleGhost()
    {
        //Ghost boss tele if player on distance of waypointleft and enemy
        if (player.transform.position.x < transform.position.x
            && player.transform.position.x > waypointLeft.transform.position.x)
        {
            float distanceWLtoE = Vector2.Distance(waypointLeft.transform.position, transform.position);
            float teleEtoWL = Random.Range(distanceWLtoE/2, distanceWLtoE);
            Debug.Log(teleEtoWL);
            transform.position -= new Vector3(teleEtoWL, 0, 0);
        }
        //Ghost boss tele if player on distance of waypointRight and enemy
        if (player.transform.position.x >transform.position.x
            && player.transform.position.x<waypointRight.transform.position.x )
        {
            float distanceWRtoE = Vector2.Distance( transform.position,waypointRight.transform.position);
            float teleEtoWR = Random.Range(distanceWRtoE / 2, distanceWRtoE);
            Debug.Log(teleEtoWR);
            transform.position += new Vector3(teleEtoWR, 0, 0);
        }
        gameObject.SetActive(true);
        //spr.enabled = false;
        Debug.Log("Run animation Appear");
        anim.SetTrigger("Appear");      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
