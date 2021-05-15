using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headpos : MonoBehaviour
{
    public Transform head;


  

    public void Update()
    {
         gameObject.transform.position = head.position;
    }
}
