using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBullet : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 40;
    public float bounce = 2f;
    public GameObject impactEffect;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        //Enemy enemy = hitInfo.GetComponent<Enemy>();
        //if (enemy != null)
        //{
        //    enemy.TakeDamage(damage);

        //}
        ////Instantiate(impactEffect, transform.position, transform.rotation);
        ////Destroy(gameObject);
        //if (hitInfo.gameObject.CompareTag("Ground"))
        //{
        //    hitInfo.gameObject.GetComponent<Rigidbody2D>().
        //        AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        //}

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ////Enemy enemy = collision.gameObject.("Enemy");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerLife>().Die();
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        ////Destroy(gameObject);
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void Delay()
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);        
    }

    
}
