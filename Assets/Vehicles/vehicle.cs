using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class vehicle : MonoBehaviour
{ 
    private float vechileneterdistance  = 7f;
    public Rigidbody rig;
    public Rigidbody tanknotmove;
    public Rigidbody test;
    public MoveCamera cameraenable;
    public Newplayer enableplayer;
    public Shotgun cannonactivate;
    public PickUp deactivte;
    public Tank tankactivte;
    public GameObject gunisenabled;
    public Transform Playerexitank;
    public Transform cameraresetrot;
    public Transform Playerintank;
    public Transform player;
    public TextMeshProUGUI guntext;
    public static bool invechicle;
    
    public static bool grounded;
    public void Tankmode()
    {

       
        deactivte.enabled = false;
        guntext.color = new Color(0, 0, 0, 0);
        gunisenabled.SetActive(false);
        invechicle = true;
        tankactivte.enabled = true;
        enableplayer.enabled = false;
        transform.SetParent(Playerintank);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.back);
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        cameraenable.enabled = false;
        rig.isKinematic = true;
       
        rig.interpolation = RigidbodyInterpolation.None;
        rig.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        cannonactivate.enabled = true;
    }
    public void PlayerMode()
    {
        
        deactivte.enabled = true;
        gunisenabled.SetActive(true);
        invechicle = false;
        cameraresetrot.localRotation = Quaternion.identity;
         enableplayer.orientation.localRotation = cameraresetrot.localRotation;
        tankactivte.enabled = false;
        enableplayer.enabled = true;
        transform.SetParent(null);
        transform.position = Playerexitank.position;
        transform.rotation = enableplayer.orientation.localRotation;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        cameraenable.enabled = true;
        rig.isKinematic = false;
        rig.interpolation = RigidbodyInterpolation.Interpolate;
        rig.collisionDetectionMode = CollisionDetectionMode.Continuous;
        cannonactivate.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(tankactivte.enabled == false)
        {
          tanknotmove.constraints = RigidbodyConstraints.FreezeAll;
          test.constraints = RigidbodyConstraints.FreezeAll;
            
        }
        if (tankactivte.enabled == true)
        {
            tanknotmove.constraints = RigidbodyConstraints.None;
            test.constraints = RigidbodyConstraints.FreezeRotation;
            
        }
        Vector3 distanceToPlayer = Playerintank.position - transform.position;
         if(enableplayer.enabled == false)
         {
         rig.position = Playerintank.position;
         transform.position = Playerintank.position;
         }
        if(  distanceToPlayer.magnitude <= vechileneterdistance && Input.GetKeyDown(KeyCode.T))
        {
            Tankmode();
        }
        if (invechicle == true && Input.GetKeyDown(KeyCode.G) && grounded)
        {
            PlayerMode();
        }
      
    }
 
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;

        }
    }
}
