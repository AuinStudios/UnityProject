using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class r : MonoBehaviour
{
    
    
    public void Update()
    {

     


        if (transform.position.y <= -90)
        {
            transform.position = new Vector3(-4, 0, 12);
        }
    }
}
