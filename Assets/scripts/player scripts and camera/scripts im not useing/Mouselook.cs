using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
    // variables to code other variables to make a  code to move  a  C AME R A 

    public float MouseSensitivity = 100f;

    public Transform Playerbody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {// code for makeing ur mouse stuck in place
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() 
    {// geting directions for the camera to move
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        //   variable for mousey and     makes the  camera     at maxium rotate 180 degress
        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        // moves the camera or just up and down not sure
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        Playerbody.Rotate(Vector3.up * MouseX);
    }
        
}    
