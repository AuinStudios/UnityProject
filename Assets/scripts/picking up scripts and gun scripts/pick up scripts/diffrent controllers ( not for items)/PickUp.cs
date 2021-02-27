
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    // variables
    public float moveForce = 250f;
    public float pickUpRange = 5f;
    public GameObject heldObj;
    public string TagName;

    public Transform holdParent;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            //if (heldObj.CompareTag(TagName))
            //{
            //  Debug.Log("Gameobject Name: " + heldObj.name);

                if (heldObj == null)
                {// the raycast
                    RaycastHit hit;
                
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange  ))
                    {

                        pickUpObject(hit.transform.gameObject);
                
                    }
                }
                else
                {
                    DropObject();
                }
            //}
        }

        if (heldObj != null)
        {
            moveObject();
        }
    }
    // moves the object to add more feel to it
    void moveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0f)
        {
            Vector3 moveDirection = holdParent.position - heldObj.transform.position;
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void pickUpObject(GameObject pickObj)
    {
        if (pickObj.CompareTag("CanPickUp"))
        {

            if (pickObj.GetComponent<Rigidbody>())
            {
                Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
                objRig.useGravity = false;
                objRig.drag = 20f;

                objRig.transform.parent = holdParent;
                heldObj = pickObj;






            }
        }
    }

    void DropObject()
    {
        heldObj.GetComponent<Rigidbody>().useGravity = true;
        heldObj.GetComponent<Rigidbody>().drag = 1f;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
