
using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    private float throwForce = 10;
    bool hasPlayer = false;
    bool beingCarried = false;
    public AudioClip[] soundToPlay;

    public int dmg;
    private bool touched = false;
    public settings settings;
    public ThrowObject throwObject;
 

    void Update()
    {
       // scriptable  objects storage
        throwObject.throwForce = settings.throwforce;
       // checking distance and the player object
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 3f)
        {// aviable to be picked up
            hasPlayer = true;
        }
        else
        {//not aviable to be picked up
            hasPlayer = false;
        }// if true is on this script is executed
        if (hasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            
            transform.parent = playerCam;
            beingCarried = true;
        }
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
            else if (Input.GetKeyDown (KeyCode.Mouse1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null; 
                beingCarried = false;
            }
        }
    }
 
       

    
   
}
