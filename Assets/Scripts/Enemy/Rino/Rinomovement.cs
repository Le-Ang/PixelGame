using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rinomovement : MonoBehaviour
{
    bool spriteR;
    [SerializeField] private float speed = 10f;
    private GameObject player;
    private Animator anim;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Rino");
        anim = enemy.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void Update()
    {
            anim.SetTrigger("RinoRun");
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //if(spriteR.flipX = true)
            //{
            //    Debug.Log(1);
            //}

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Waypoint"))
        {
            anim.SetTrigger("RinoHitWall");
            spriteR = !spriteR;
            
        }

        if (spriteR)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
