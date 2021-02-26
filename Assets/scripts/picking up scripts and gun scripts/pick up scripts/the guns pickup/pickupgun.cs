using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;





public class pickupgun : MonoBehaviour
{
    public Newgun gunscript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;
    //public GunsScriptableObject scriptableobject2;
    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;
    //public TextMeshProUGUI popup;
    public bool equipped;
    public static bool slotFull;
    //public GameObject yes;
    public TextMeshProUGUI ammoui;
    
     void Awake()
    {
            //popup.text = scriptableobject2.Name + "\n";
            //popup.transform.position = yes.transform.position;
        
        
    }

    
    private void Start()
    {
        //Setup
        if (!equipped)
        {
            gunscript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
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
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        //Drop if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();

        


     
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;
        ammoui.color = new Color(233, 210, 21, 255);
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

    private void Drop()
    {
        equipped = false;
        slotFull = false;
        ammoui.color = new Color(0, 0, 0, 0);
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
        rb.AddTorque(new Vector3(random, random, random) * 10);

        //Disable script
        gunscript.enabled = false;
        
    }
}
