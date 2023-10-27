using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PigEnemy : MonoBehaviour
{
    public static float speed = 2f;
    //private SpriteRenderer spriteR;
    //bool spriteR;
    [SerializeField] private float bounce = 4f;
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private SpriteRenderer spriteR;
    private Animator anim;
    private GameObject enemy;
    private GameObject player;
    [SerializeField] private float distanceView = 5f;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Pig");
        anim = enemy.GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.transform.position,
           transform.position);
        if (distance <= distanceView)
        {
            anim.SetTrigger("Run");
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position,
            transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
                spriteR.flipX = !spriteR.flipX;
                //if(spriteR.flipX = true)
                //{
                //    Debug.Log(1);
                //}

            }
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
            //transform.Translate(Vector2.left * speed * Time.deltaTime);
            //if(spriteR.flipX = true)
            //{
            //    Debug.Log(1);
            //}
        }
        else
        {
            anim.SetTrigger("Idle");
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Waypoint"))
    //    {
    //        spriteR = !spriteR;
    //    }

    //    if (spriteR)
    //    {
    //        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    //    }
    //    else
    //    {
    //        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    //    }
    //}

}
