using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplatform : MonoBehaviour
{

    public GameObject player;
    public  GameObject object2;



    public void OnCollisionExit(Collision collision)
    {
        player.transform.parent = null;
      
    }

    public void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.parent = object2.transform;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
