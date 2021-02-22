using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class timestopmaybe : MonoBehaviour
{



    public GameObject equip;
    public float Power = 100.0f;
    public float UpPower = 50.0f;
    public camerashake Camerashake;
    public Color GizmosColor;
    public float radius = 60.0f;
    private Transform target;
    public TimeSlowmaybetimestop Timemanager;

    // Start is called before the first frame update
    void Start()
    {
        target = Playermanager.instance.Player.transform;
    }

    public void Update()
    {
       
        {
       // if (Input.GetKeyDown(KeyCode.T))
       // {
         //   Timemanager.time();
       // }
        }


        

        
        if (Input.GetKeyDown(KeyCode.F))
        {           
            
            blow();
            StartCoroutine(Camerashake.Shake(.10f, .8f));


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

               
                if (rb != null && !HIT.CompareTag("gun") && !HIT.CompareTag("delete") && !HIT.CompareTag("bullet"))
                {
                    rb.AddExplosionForce(Power, explosionpos, radius, UpPower, ForceMode.Impulse);


                }
            }
           
            
        }
    }
    
    void OnDrawGizmos()
    {
#if UNITY_EDITOR
        
        Gizmos.color = GizmosColor;
        Gizmos.DrawWireSphere(transform.position, radius);

#endif
    }
}   


