using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newplayer : MonoBehaviour
{
    public Rigidbody rig;
    public Transform player;
    public float maxspeed = 300f;
    private float forwardspeed =17000f;
    private float dash = 1000000f;
    private float backwards = -17000f;
    private float right = 17000f;
    private float left = -17000f;
    public GameObject GFX;
    public float jumpower = 60000f;
    public bool isgroundedboi;
    private float dontjump = -6f;
    public ParticleSystem speedeffect;
    private float sensitivity = 50f;
    private float sensMultiplier = 1f;
    public Transform orientation;
    public PlayerHealthHandler health;
    private float maxVertSpeed = 200;
    void FixedUpdate()
    {
       

        Vector3 xzVel = new Vector3(rig.velocity.x, 0, rig.velocity.z);
        Vector3 yVel = new Vector3(0, rig.velocity.y, 0);

        xzVel = Vector3.ClampMagnitude(xzVel, maxspeed);
        yVel = Vector3.ClampMagnitude(yVel, maxVertSpeed);

        rig.velocity = xzVel + yVel;


        if (rig.velocity.magnitude > maxspeed)
        {
          speedeffect.Play();
        }

      

        if (rig.velocity.magnitude < maxspeed)
        {
            speedeffect.Stop();
        }

        if (isgroundedboi && !(health.Health <= 0))
        {
            
            rig.drag = 10;
            forwardspeed = 5000f;
            backwards = -5000f;
            right = 5000f;
            left = -5000f;
        }
        if (!isgroundedboi )
        {

            rig.AddForce(player.up * dontjump * Time.deltaTime, ForceMode.VelocityChange);
            
            rig.drag = 1;
            forwardspeed = 500;
            backwards = -500;
            right = 500;
            left = -500;
        }
        if (isgroundedboi && (Input.GetKey(KeyCode.Space)) )
        {
            rig.AddForce(player.up * jumpower * Time.fixedDeltaTime, ForceMode.Impulse);
            

        }
    }

   


    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime * sensMultiplier;

        
        orientation.Rotate(Vector3.up * mouseX);
        //SHIT FUCKING HORRIBLE  MOVEMENT CODE
        if (Input.GetKey(KeyCode.W))
        {
            rig.AddForce(player.forward * forwardspeed * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rig.AddForce(player.forward * backwards * Time.deltaTime, ForceMode.Impulse);
        } 
        if (Input.GetKey(KeyCode.D))
        {
            rig.AddForce(player.right * right * Time.deltaTime, ForceMode.Impulse);
           
        }
       
        if (Input.GetKey(KeyCode.A))
        {
            rig.AddForce(player.right * left * Time.deltaTime, ForceMode.Impulse);
            
        }
       
        if((Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.W) && isgroundedboi)))
        {
            left = -2700f;
            forwardspeed = 2700;
        }

        if ((Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.W) && isgroundedboi)))
        {
            right = 2700f;
            forwardspeed = 2700;
        }

        if ((Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.S) && isgroundedboi)))
        {
            right = 2700f;
            backwards = -2700;
        }

        if ((Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.S) && isgroundedboi)))
        {
            left = -2700f;
            backwards = -2700;
        }
       
 if (Input.GetKeyDown(KeyCode.H) && !isgroundedboi)
        {
            rig.velocity = Vector3.ClampMagnitude(rig.velocity, 1000);
            rig.AddForce(player.forward * dash * Time.deltaTime, ForceMode.VelocityChange);

        }
     

        if(health.Health <= 0  )
        {
            forwardspeed = 0f;
            backwards = -0f;
            right = 0f;
            left = -0f;
            sensitivity = 0f;
            sensMultiplier = 0;
        }
        if(Time.timeScale == 0)
        {
            forwardspeed = 0f;
            backwards = -0f;
            right = 0f;
            left = -0f;
            sensitivity = 0f;
            sensMultiplier = 0;
        }
        if(Time.timeScale == 1 && !(health.Health <= 0))
        {
            sensitivity = 50f;
            sensMultiplier = 1;
        }
       




       
        transform.position = GFX.transform.position;

        

    }
    public void OnTriggerEnter(Collider other)
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

