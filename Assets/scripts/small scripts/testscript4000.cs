using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript4000 : MonoBehaviour
{
    public Transform gayboy;
    
    // Update is called once per frame
    void Update()
    {
        
    }







    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("test3000"))
        {
            transform.position = gayboy.position;
        }

        

       
    }
 

}
