using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonEnemy : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    private Collider2D coll;
    [SerializeField] float distanceView = 4f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    private void Update()
    {
        float distance = Vector2.Distance(player.transform.position,
            transform.position);
        if (distance <= distanceView)
        {
            anim.SetTrigger("Attack");
            coll.isTrigger = false;
        }
        else
        {
            anim.SetTrigger("Idle");
            coll.isTrigger = true;
        }

    }
}
