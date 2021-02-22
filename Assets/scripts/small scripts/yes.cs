using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yes : MonoBehaviour
{










    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    
   


    private void OnCollisionEnter(Collision collision)
    {
      if (gameObject.tag == "pressed")
      {      
         transform.position = new Vector3(-36, 2, -6);       
      }         
        
           
        
    }
}
       





