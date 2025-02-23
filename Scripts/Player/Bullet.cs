using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 40;
    public float bounce = 2f;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ////Enemy enemy = collision.gameObject.("Enemy");
        if (collision.gameObject.CompareTag("Pig"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
        ////Destroy(gameObject);
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<Rigidbody2D>().
               AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            Invoke("Delay", 0.5f);
        }
        if (collision.gameObject.CompareTag("Body"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
    }
    private void Delay()
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
