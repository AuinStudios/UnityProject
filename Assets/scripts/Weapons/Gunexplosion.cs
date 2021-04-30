using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunexplosion : MonoBehaviour
{
 
    public GameObject equip;
    public float blowtimer = 2f;
    public GunsScriptableObject scriptableobject;
    public RaycastHit hit;
    public GameObject impacteffect;
    public GameObject explosiondamage;
    public void Start()
    {
     
    }

   


    public void OnTriggerEnter(Collider other)
    {
           




        if (other.gameObject.CompareTag("forcefield"))
        {
            blow();
            
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("gun"))
        {

          equip = this.gameObject;
            
        }
         
     if (collision.gameObject.CompareTag("gun"))
        {
            Invoke("blow", blowtimer ) ;
            
        }
        if (gameObject.CompareTag("gun"))
        {
            Invoke("blow", blowtimer);

        }
        if (collision.gameObject &&  !gameObject.CompareTag("explosivebarrel"))
        {
            blow();

        }
    }





    void blow()
    {
        
       

        Vector3 explosionpos = equip.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionpos, scriptableobject.explosionRange);
        foreach (Collider HIT in colliders)
        {
            Rigidbody rb = HIT.GetComponent<Rigidbody>();

            if (!HIT.CompareTag("Player"))
            {
                if (rb != null && (!HIT.CompareTag("gun")))
                {
                    rb.AddExplosionForce(scriptableobject.powerOfExplosion, explosionpos, scriptableobject.explosionRange, scriptableobject.upPowerExplosion, ForceMode.Impulse);

                }
            }





            if (HIT.CompareTag("Player"))
            {
                rb.AddExplosionForce(scriptableobject.playerExplosionForce, explosionpos, scriptableobject.explosionRange, scriptableobject.playerUpForce, ForceMode.Impulse);
            }



            Instantiate(impacteffect, transform.position, transform.rotation);
            Instantiate(explosiondamage, transform.position, transform.rotation);
            if (gameObject.name == "grenadelauncherammo(Clone)")
            {
                Destroy(gameObject);

            }


            if (gameObject.name == "explosivebarrel")
            {
                Destroy(gameObject);

            }

        }

    }
}