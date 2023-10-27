using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float bounce = 10f;
    [SerializeField] private Collider2D[] coll;
    private Animator anim;
    private GameObject enemy;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Pig");//Thay lai ten tag va script cau
                                                        //hinh tag Enemy de thuc hien duoc voi
                                                        //nhieu loai enemy khac nhau
        anim = enemy.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            anim.SetTrigger("Death");
            Invoke("PigDeath",1f);
        }
    }
    private void PigDeath()
    {
            
        for(int i = 0; i < coll.Length; i++) 
        {
            coll[i].isTrigger = true; 
        }
            
    }
}
