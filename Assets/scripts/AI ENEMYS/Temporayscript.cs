using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporayscript : MonoBehaviour
{


    public shootingAI enemy;


    // Update is called once per frame
    void Update()
    {
        
        if (enemy.health == 0)
        {
            transform.position =  new Vector3 (0,100,0);
           
        }
    }
}
