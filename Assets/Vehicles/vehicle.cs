using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicle : MonoBehaviour
{ 
    private float vechileneterdistance  = 7f;
    public Rigidbody rig;
    public MoveCamera cameraenable;
    public Newplayer enableplayer;
    public Shotgun cannonactivate;
    public Tank tankactivte;
    public GameObject gunisenabled;
    public Transform Playerexitank;
    public Transform cameraresetrot;
    public Transform Playerintank;
    public Transform player;
    public static bool invechicle;
 public void Tankmode()
    {
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
         Vector3 distanceToPlayer = Playerintank.position - transform.position;
         if(enableplayer.enabled == false)
         {
         rig.position = Playerintank.position;
         transform.position = Playerintank.position;
         }
        if(  distanceToPlayer.magnitude <= vechileneterdistance && Input.GetKeyDown(KeyCode.E))
        {
            Tankmode();
        }
        if (invechicle == true && Input.GetKeyDown(KeyCode.G))
        {
            PlayerMode();
        }
    }




  
}
