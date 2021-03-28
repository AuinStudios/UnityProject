using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporayscript : MonoBehaviour
{

    public ENEMYHEALTH health;
    public shootingAI enemy;


    // Update is called once per frame
    void Update()
    {
        
        if (enemy.test.health == 0)
        {
            transform.position =  new Vector3 (0,100,0);
           
        }
    }
}
