using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rino : MonoBehaviour
{

    public float bounce = 10f;
    //[SerializeField] private Collider2D coll;


    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

        enemy = GameObject.Find("Rino");//Thay lai ten tag va script cau
                                                        //hinh tag Enemy de thuc hien duoc voi
                                                        //nhieu loai enemy khac nhau

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().
                AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            //anim.SetTrigger("Hit");
            //Invoke("Delay", 0.1f);
        }
    }

    
    private void Delay()
    {
        //anim.SetTrigger("Angry");
        //coll.isTrigger = true;
    }
}
