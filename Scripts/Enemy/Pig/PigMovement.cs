using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PigMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private SpriteRenderer spriteR;
    private GameObject player;
    private Animator anim;
    [SerializeField] private float distanceView = 4f;
    public static float speed = 2f;

    private void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
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
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position,
                waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
            }     
        }
        else
        {
            anim.SetTrigger("Idle");
        }
    }
}
