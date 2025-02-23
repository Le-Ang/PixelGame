using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ChickenEnemy : MonoBehaviour
{
    [SerializeField] private GameObject waypoints;
    //private int currentWaypointIndex = 0;
    public GameObject player; //the player object
    public float speed = 5f; //the speed of the enemy
    private Animator anim;
    private SpriteRenderer sr; //the sprite renderer component
    [SerializeField] private float distanceView = 4f;
    void Start()
    {
        //get the sprite renderer component
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //distance from chicken to player
        float distance = Vector2.Distance(player.transform.position,
            transform.position);
        if (distance <= distanceView)
        {
            Debug.Log("Chicken Run");
            //check distance from chicken to player in y axis
            if ((player.transform.position.y - waypoints.transform.position.y) <= 2f)
            {
                anim.SetTrigger("Run");
                transform.position = Vector2.MoveTowards(transform.position,
                player.transform.position, Time.deltaTime * speed);
                if (transform.position.x > player.transform.position.x)
                {
                    sr.flipX = false;
                }
                else
                {
                    sr.flipX = true;
                }
            }
            else
            {
                anim.SetTrigger("Idle");
            }
        }        
        else
        {
            anim.SetTrigger("Idle");
        }
    }
}
