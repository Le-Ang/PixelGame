using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit_Movement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private SpriteRenderer spriteR;
    [SerializeField] private float speed = 2f;
    [SerializeField]private float distanceView = 4f;
    private GameObject player;
    private Animator rabanim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rabanim = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position,
            transform.position);
        if (distance <= distanceView)
        {
            rabanim.SetTrigger("Run");
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
        }
        else
        {
            rabanim.SetTrigger("Idle");
        }

    }
}
