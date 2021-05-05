using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunexplosion : MonoBehaviour
{
   
    public GameObject equip;
    public float blowtimer = 2f;
    public GunsScriptableObject scriptableobject;
    public RaycastHit hit;
    public GameObject impacteffect, explosiondamage  ;
   

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("forcefield"))
        {

            equip = this.gameObject;

        }





        if (other.gameObject.CompareTag("forcefield"))
        {
            blow();
         
        }
    }

    public void FixedUpdate()
    {
        if (equip == enabled)
        {
            Invoke("blow", blowtimer );

        }
    }

   

    public void OnCollisionEnter(Collision collision)
    {

        if(gameObject.CompareTag("explosivebarrel") && collision.gameObject.CompareTag("bullet"))
        {
            equip = this.gameObject;
        }

        if (collision.gameObject.CompareTag("explosiveammo"))
        {

            equip = this.gameObject;

        }
  
        if (collision.gameObject &&  !gameObject.CompareTag("explosivebarrel") && !collision.gameObject.CompareTag("gun"))
        {
            blow();
        }

        
    }
  
    public void blow()
    {



        
         Instantiate(impacteffect, transform.position, transform.rotation);
        Vector3 explosionpos = equip.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionpos, scriptableobject.explosionRange);
        foreach (Collider HIT in colliders)
        {
            Rigidbody rb = HIT.GetComponent<Rigidbody>();
            
            if (!HIT.CompareTag("Player"))
            {

                if (rb != null && (!HIT.CompareTag("explosiveammo")&& !HIT.CompareTag("bullet") && !HIT.CompareTag("explosivebarrel")))
                {
                    rb.AddExplosionForce(scriptableobject.powerOfExplosion, explosionpos, scriptableobject.explosionRange, scriptableobject.upPowerExplosion, ForceMode.Impulse);

                }
            }
            if (gameObject.CompareTag("explosivebarrel"))
            {
                Instantiate(explosiondamage, transform.position, transform.rotation);
            }
             if (HIT.CompareTag("enemy"))
             {
                Instantiate(explosiondamage, transform.position, transform.rotation);

             }
          
            if (HIT.CompareTag("Player"))
            {
                rb.AddExplosionForce(scriptableobject.playerExplosionForce, explosionpos, scriptableobject.explosionRange, scriptableobject.playerUpForce, ForceMode.Impulse);
               
            }

               if (gameObject.name == "grenadelauncherammo(Clone)")
                {
                    Destroy(gameObject);

                }


                if (gameObject.name == "Explosivebarrel")
                {
                    Destroy(gameObject);

                }
                if (gameObject.name == "barreldamage(Clone)")
                {
                Destroy(gameObject);

            }
        }

        }
    }    