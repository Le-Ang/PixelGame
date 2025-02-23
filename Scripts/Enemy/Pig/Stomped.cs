using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Stomped : MonoBehaviour
{
    enum pigState { IDLE, ANGRY, DIE};

    public float bounce = 10f;
    private Animator anim;
    
    private pigState currentState;

    GameObject parentGO;
    Enemy animEnemy;
    [SerializeField] private BoxCollider2D pigBody;
    BoxCollider2D colliderPig;
    // Start is called before the first frame update
    void Start()
    {

        currentState = pigState.IDLE;

        Transform parent = transform.parent;
        anim = parent.GetComponent<Animator>();
        animEnemy = parent.GetComponent<Enemy>();
        Debug.Log(animEnemy.health);
        Debug.Log(anim.isHuman);
        colliderPig = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().
                AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            if(anim)
            anim.SetTrigger("Hit");
            else
            {
                Debug.Log("Anim is null");
            }
            if (currentState == pigState.IDLE)
            {
                Debug.Log("Pig is angry");
                currentState = pigState.ANGRY;
                PigMovement.speed = 4f;
                anim.SetTrigger("Angry");
            }
            else if(currentState == pigState.ANGRY) 
            { 
                currentState = pigState.DIE;
                anim.SetTrigger("Death");
                colliderPig.isTrigger = true;
                transform.parent.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                transform.parent.gameObject.AddComponent<Rigidbody2D>();
                transform.parent.parent.GetComponent<Transform>().position += new Vector3(0,0,1f); 
                Invoke("Delay", 1.0f);
            }
        }
    }
    private void Delay()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
