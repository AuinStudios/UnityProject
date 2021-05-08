using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destorybullet : MonoBehaviour
{
    public int timer = 10;
    public ParticleSystem impacteffect;
    public Material worpls;
    

    public void Start()
    {
        Invoke("destorystuff", timer);
    }
    private void OnTriggerEnter(Collider collider)
    {
      if (collider.gameObject.tag == "forcefield")
        {
            destorystuff();
            worpls.color = Color.cyan;
        }
    }




    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Untagged")
        {
            destorystuff();
            worpls.color = Color.white;
            
        }

        if (collision.gameObject.tag == "explosivebarrel")
        {
            destorystuff();
        }
        if (collision.gameObject.tag == "wall")
        {
            destorystuff();
            worpls.color = Color.yellow;
        }

        if (collision.gameObject.tag == "enemy")
        {
            destorystuff();
            worpls.color = Color.black;
        }

        if (collision.gameObject.tag == "Player")
        {
           destorystuff();
            worpls.color = Color.red;
        }

        if (collision.gameObject.tag == "bananakatana")
        {
            destorystuff();
            worpls.color = Color.grey;
        }

        if (collision.gameObject.tag == "gun")
        {
            destorystuff();
            worpls.color = Color.grey;
        }
       

        if (collision.gameObject.tag == "delete")
        {
            destorystuff();
            worpls.color = Color.white;
        }



        if (collision.gameObject.tag == "CanPickUp")
        {
            destorystuff();
            worpls.color = Color.black;
        }
    }

    
   public void Update()
    {
        if (gameObject.name == ("timebullet(Clone)"))
        {
            destorystuff();
        }
        if (gameObject.name == ("pleasework(Clone)"))
        {
            destorystuff();
        }

        if (gameObject.name == ("bullet(Clone)"))
        {
            destorystuff();

        }
    }


   
   public void destorystuff()
    {
        Destroy(gameObject);
        Instantiate(impacteffect, transform.position, transform.rotation);
       

    }




}
