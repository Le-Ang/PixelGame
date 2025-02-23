using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatWayPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private SpriteRenderer spriteR;
    [SerializeField] private float speed = 2f;

    private void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position,
            transform.position)< .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
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

}
