using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headpos : MonoBehaviour
{
    public Transform head;
    public MoveCamera e;
   
    public Transform cameranewpos;
  

    public void Update()
    {
        if(e.enabled == false)
        {
            gameObject.transform.position = cameranewpos.position;
            gameObject.transform.rotation = cameranewpos.rotation;
        }
        if(e.enabled == true)
        {
         gameObject.transform.position = head.position;  
        }
        
    }
}
