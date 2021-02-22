using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notuseing : MonoBehaviour
{// variable
    public float health = 1000f;
    // makes  target take damage
    public void Takedamage(float amount)
    {// this takes amount of  damage the target took and if the health is below 1 it di e s
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
         // makes object dissaperr from existance
        void Die()
        {
            Destroy(gameObject);
        }

    }    
} 
  


