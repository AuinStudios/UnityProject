using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem death;
    public void takedamage (float amount)
    {
        health -= amount;
        if (health <= 0f )
        {
            die();
        }
    }
     void die()
     {
        Destroy(gameObject);
        Instantiate(death, transform.position, Quaternion.identity);
     }

}
