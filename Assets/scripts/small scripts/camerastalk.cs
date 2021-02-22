using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camerastalk : MonoBehaviour
{
    public Transform pp;
    
   
    // Update is called once per frame
    void Update()
    {
        facetarget();

        
    }







    void facetarget()
    {
        Vector3 direction = (pp.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5f);
    }


}


