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
    private float dontjump = 0f;
    public ParticleSystem speedeffect;
    private float sensitivity = 50f;
    private float sensMultiplier = 1f;
    public Transform orientation;
    Vector3 v3;
    void FixedUpdate()
    {

        if (rig.velocity.magnitude > maxspeed && !isgroundedboi)
        {

            speedeffect.Play();

            rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxspeed);
        }

        if (rig.velocity.magnitude < maxspeed && isgroundedboi)
        {
            speedeffect.Stop();
        }



    }

   


    // Update is called once per frame
    void Update()
    {
           v3 = rig.velocity;



        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime * sensMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime * sensMultiplier;

        
        orientation.Rotate(Vector3.up * mouseX);
        if (Input.GetKey(KeyCode.W) && isgroundedboi)
        {
            rig.AddForce(player.forward * forwardspeed * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W) && !isgroundedboi)
        {
            rig.AddForce(player.forward * forwardspeed * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.H) && !isgroundedboi)
        {
            rig.velocity = Vector3.ClampMagnitude(rig.velocity, 1000);
            rig.AddForce(player.forward * dash * Time.deltaTime, ForceMode.Impulse);

        }
        if (Input.GetKey(KeyCode.S) &&isgroundedboi)
        {
            rig.AddForce(player.forward * backwards * Time.deltaTime, ForceMode.Impulse);
           
        }

        if (Input.GetKey(KeyCode.S) && !isgroundedboi)
        {
            rig.AddForce(player.forward * backwards * Time.deltaTime, ForceMode.Impulse);

        }
        if (Input.GetKey(KeyCode.D) && isgroundedboi)
        {
            rig.AddForce(player.right * right * Time.deltaTime, ForceMode.Impulse);
           
        }

        if (Input.GetKey(KeyCode.D) && !isgroundedboi)
        {
            rig.AddForce(player.right * right * Time.deltaTime, ForceMode.Impulse);

        }


        if (Input.GetKey(KeyCode.A) && isgroundedboi)
        {
            rig.AddForce(player.right * left * Time.deltaTime, ForceMode.Impulse);
            
        }

        if (Input.GetKey(KeyCode.A) && !isgroundedboi)
        {
            rig.AddForce(player.right * left * Time.deltaTime, ForceMode.Impulse);
            
        }


        if (!isgroundedboi)
            {
            rig.AddForce(player.up * dontjump * Time.deltaTime, ForceMode.Impulse);


            forwardspeed = 500;
            backwards = -500;
            right = 500;
            left = -500;
            }


        if (isgroundedboi && (Input.GetKeyDown(KeyCode.Space)))
        {
            rig.AddForce(player.up * jumpower * Time.fixedDeltaTime, ForceMode.Impulse);
            v3.x = 0;
            v3.z = 0;
        }

        if (isgroundedboi)
        {

            v3.x = 0;
            v3.z = 0;
            forwardspeed = 15000f;
            backwards = -15000f;
            right = 15000f;
            left = -15000f;
        }



        rig.velocity = v3;
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

