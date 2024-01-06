using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float currentHealth = 100;
    public HealthBar healthBar;
    private float playerBlood = 100;
    private float bounce = 3f;

    //[SerializeField] private AudioSource deathSoundEffect;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currentHealth = playerBlood;
        healthBar.SetMaxHealth(playerBlood);
    }

    private void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tagofthis = collision.gameObject.name;
        Debug.Log(tagofthis);
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (currentHealth <= 0)
            {
                anim.SetTrigger("death");
                Die();
            }
            else
            {
                TakeDamage(25);
                Bounce();
            }            
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (currentHealth <= 0)
            {
                anim.SetTrigger("death");
                Die();
            }
            else
            {
                TakeDamage(25);
                Bounce();
            }
        }
        if (collision.gameObject.CompareTag("BulletGhost"))
        {
            if (currentHealth <= 0)
            {
                anim.SetTrigger("death");
                Die();
            }
            else
            {
                TakeDamage(25);
                Bounce();
            }
        }
        
        //Debug.Log(collision.GetType().ToString());
        //if (collision.gameObject.CompareTag("Pig"))
        //{
        //    if(collision.GetType() == typeof(BoxCollider2D))
        //    Die();
        //}

    }

    //private void OnCollisionEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Body"))
    //    {
    //        Die();
    //    }
    //}

    public void Die()
    {
        GameObject.FindGameObjectWithTag("SoundManager").
                GetComponent<SoundManager>().PlaySoundEffect(MusicEffect.DIE);
        rb.bodyType = RigidbodyType2D.Static;
        
        ClassScore.getInstance().setScore(0);
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    private void Bounce()
    {
        gameObject.GetComponent<Rigidbody2D>().
                AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
    }
}
