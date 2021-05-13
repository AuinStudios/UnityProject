using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;





public class pickupgun : MonoBehaviour
{

 //Super Important Ones----------------------------------------------------------------------------
 public Shotgun gunscript;
 public PlayerHealthHandler playerhealth;
 public Rigidbody rb;
 public Transform player, gunContainer, fpsCam;
 public BoxCollider coll;
 //Floats------------------------------------------------------------------------------------------
 public float pickUpRange;
 public float dropForwardForce, dropUpwardForce;
 //Ui-----------------------------------------------------------------------------------------------
 public TextMeshProUGUI ammoui;
 // GunFluidmovement -------------------------------------------------------------------------------
 public Gunfluidmovement fluid;
 //Bools------------------------------------------------------------------------------------------
 public bool equipped;
 public bool isfluidEnabled = false;
 public static bool color;
 public static bool slotFull;
 //Stuff Im Not Useing -----------------------------------------------------------------------------
 //public GunsScriptableObject scriptableobject2;
     //public TextMeshProUGUI popup;
     //public GameObject yes;   
 // ------------------------------------------------------------------------------------------------    

    private void Start()
    {
        //Setup
        if (!equipped)
        {
            
            gunscript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            slotFull = false;
        }
        if (equipped)
        {
           
            gunscript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

   
    private void Update()
    {

        if (slotFull == false && transform.position.y <= -90)
        {
            transform.position = new Vector3(0, 0, 0);
        }

        if (isfluidEnabled == true)
        {
            fluid.enabled = true;
        }

        if (isfluidEnabled == false)
        {
            fluid.enabled = false;
        }
        if (color == false)
        {
            ammoui.color = new Color(0, 0, 0, 0);
        }
        if (color == true)
        {
            ammoui.color = new Color(233, 210, 21, 255);
        }
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && !(playerhealth.Health <= 0) && slotFull == false && Input.GetKeyDown(KeyCode.E) ) PickUp() ;
     
        //Drop if equipped and "Q" is pressed
        if (equipped && slotFull == true && Input.GetKeyDown(KeyCode.Q)) Drop();

    }

    public void PickUp()
    {
        equipped = true;
        slotFull = true;
        isfluidEnabled = true;
        color = true;
        //Make weapon a child of the camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.back);
        transform.localScale = Vector3.one;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;
       
        //Enable script
        gunscript.enabled = true;
    }

    public void Drop()
    {
        equipped = false;
        slotFull = false;
        isfluidEnabled = false;
        color = false;
        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 100);

        //Disable script
        gunscript.enabled = false;
        
    }
}
