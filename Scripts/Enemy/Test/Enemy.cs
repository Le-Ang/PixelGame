using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    [SerializeField] private Text cherriesText;
   
    public GameObject deathEffect;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();        
            ClassScore.getInstance().scoreIncrease(1);
            cherriesText.text = "Score: " + ClassScore.getInstance().getScore();
        }    
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void TrainAnimation(string anim)
    {
        
    }

}
