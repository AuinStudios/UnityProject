using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tank : MonoBehaviour
{
   

    public Rigidbody rig;
    public Transform player;
    public float maxspeed = 300f;
    private float forwardspeed = 17000f;
    private float backwards = -17000f;
    private float right = 17000f;
    private float left = -17000f;
    public bool isgroundedboi;
    private float sensitivity = 0.1f;
    private float sensMultiplier = 0.1f;
    public PlayerHealthHandler health;
    public Transform aimcannon;
    private float maxVertSpeed = 200;
    private float xRotation = 0f;
    public Transform tankturn;
    public GameObject gfx;
    public GameObject cameraposrot;
    void FixedUpdate()
    {
        Vector3 xzVel = new Vector3(rig.velocity.x, 0, rig.velocity.z);
        Vector3 yVel = new Vector3(0, rig.velocity.y, 0);

        xzVel = Vector3.ClampMagnitude(xzVel, maxspeed);
        yVel = Vector3.ClampMagnitude(yVel, maxVertSpeed);

        rig.velocity = xzVel + yVel;

        if (isgroundedboi && !(health.Health <= 0))
        {
            
            rig.drag = 10;
            forwardspeed = 15000f;
            backwards = -15000f;
            right = 50f;
            left = -50f;
        }
        if (!isgroundedboi)
        {

            rig.drag = 0f;
            rig.constraints = RigidbodyConstraints.FreezeRotationY;
                
            
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.rotation = cameraposrot.transform.rotation;
        gfx.transform.position = transform.position;

        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime * sensMultiplier;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime * sensMultiplier;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -20, 10);
        aimcannon.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        tankturn.Rotate(Vector3.up * mouseX);
        
        //SHIT FUCKING HORRIBLE  MOVEMENT CODE
        if (Input.GetKey(KeyCode.W) && isgroundedboi)
        {
            rig.AddForce(player.forward * forwardspeed * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S) && isgroundedboi)
        {
            rig.AddForce(player.forward * backwards * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D) && isgroundedboi)
        {
            gfx.transform.Rotate(Vector3.up *  right * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.A) && isgroundedboi)
        {
            gfx.transform.Rotate(Vector3.up * left * Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            gfx.transform.rotation = Quaternion.identity;
        }
            if (health.Health <= 0)
            {
            forwardspeed = 0f;
            backwards = -0f;
            right = 0f;
            left = -0f;
            sensitivity = 0f;
            sensMultiplier = 0;
            }
        if (Time.timeScale == 0)
        {
            forwardspeed = 0f;
            backwards = -0f;
            right = 0f;
            left = -0f;
            sensitivity = 0f;
            sensMultiplier = 0;
        }
        if (Time.timeScale == 1 && !(health.Health <= 0))
        {
            sensitivity = 50f;
            sensMultiplier = 1;
        }
    }
  
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isgroundedboi = true;

        }

      

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isgroundedboi = false;

        }
    }

}