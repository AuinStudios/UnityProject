using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destorybullet : MonoBehaviour
{
    public int timer = 10;




    private void OnTriggerEnter(Collider collider)
    {
      if (collider.gameObject.tag == "forcefield")
        {
            Destroy(gameObject);
        }
    }




    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Untagged")
        {
            Destroy(gameObject);
        }

        




        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }



        if (collision.gameObject.tag == "gun")
        {
            Destroy(gameObject);
        }


        if (collision.gameObject.tag == "delete")
        {
            Destroy(gameObject);
        }



        if (collision.gameObject.tag == "CanPickUp")
        {
            Destroy(gameObject);
        }
    }

    
   public void Update()
    {
       
        if (gameObject.name == ("timebullet(Clone)"))
        {
            Destroy(gameObject, timer);
        }


        if (gameObject.name == ("bullet(Clone)"))
        {
            Destroy(gameObject, timer);
        }
    }


   
   




}
