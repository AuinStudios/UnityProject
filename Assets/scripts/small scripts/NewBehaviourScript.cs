using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Transform player;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Player")
        {
            transform.position = new Vector3(-30, -2, -6);
      
        }
       



        if (transform.position.y == -2)
        {
            if (gameObject.tag == "pressed")
            {
                transform.position = new Vector3(-30, -1, -6);
            }
        }
    }



}
