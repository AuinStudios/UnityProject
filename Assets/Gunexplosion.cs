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
    public void Start()
    {
      if (equip == enabled)
        {
            Invoke("blow", blowtimer);
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
                    rb.AddExplosionForce(scriptableobject.powerofexplosion, explosionpos, scriptableobject.explosionRange, scriptableobject.uppowerexplosion, ForceMode.Impulse);
                }
            }
                




                if (HIT.CompareTag("Player"))
                {
                rb.AddExplosionForce(scriptableobject.playersexplosionforce, explosionpos, scriptableobject.explosionRange, scriptableobject.playersupforce, ForceMode.Impulse);
                }



            Instantiate(impacteffect, transform.position, transform.rotation);
            if (gameObject.name == "test(Clone)")
            {
   Destroy(gameObject);
            }
         



            
        }

    }
}

    




