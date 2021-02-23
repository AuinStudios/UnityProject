using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunexplosion : MonoBehaviour
{
    public GameObject equip;
    public float Power = 100.0f;
    public float UpPower = 50.0f;
    public float radius = 60.0f;



    public void Start()
    {
        if (equip == enabled)
        {
            Invoke("blow", 0);
        }
    }


   





    void blow()
    {



        Vector3 explosionpos = equip.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionpos, radius);
        foreach (Collider HIT in colliders)
        {
            Rigidbody rb = HIT.GetComponent<Rigidbody>();
            if (!HIT.CompareTag("Player"))
            {
                if (rb != null && (!HIT.CompareTag("gun")))
                {
                    rb.AddExplosionForce(Power, explosionpos, radius, UpPower, ForceMode.Impulse);
                }









            }
        }

    }
}

    




