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
    public GameObject uitransformation;
    public PlayerHealthHandler health;
    public ParticleSystem transformationeffect;
    
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
        if(transformationeffect.isPlaying == false)
        {
            uitransformation.GetComponent<CanvasGroup>().alpha = 0f;
        }
        if (Input.GetKeyDown(KeyCode.B) && (gameObject.transform.localScale != new Vector3 (10,10,10)))
        {
            transformationeffect.Play();
            uitransformation.GetComponent<CanvasGroup>().alpha = 0.5f;
            
            jumpower = 100000f;
            maxspeed = 300f;
            gameObject.transform.localScale = new Vector3(10, 10, 10);
        }
        if (Input.GetKeyDown(KeyCode.N) && (gameObject.transform.localScale == new Vector3(10, 10, 10)))
        {
            transformationeffect.Play();
            uitransformation.GetComponent<CanvasGroup>().alpha = 0.5f;
            jumpower = 30000f;
            maxspeed = 30f;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (!isgroundedboi )
        {
            rig.AddForce(player.up * dontjump * Time.deltaTime, ForceMode.Impulse);

            rig.drag = 0;
            forwardspeed = 500;
            backwards = -500;
            right = 500;
            left = -500;
        }

        if(health.Health <= 0  && isgroundedboi )
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
        if(Time.timeScale == 1)
        {
            sensitivity = 50f;
            sensMultiplier = 1;
        }
        if (isgroundedboi && (Input.GetKeyDown(KeyCode.Space)) )
        {
            rig.AddForce(player.up * jumpower * Time.fixedDeltaTime, ForceMode.Impulse);
            
        }

        if (isgroundedboi && !(health.Health == 0))
        {

            rig.drag = 15;
            forwardspeed = 8000f;
            backwards = -8000f;
            right = 8000f;
            left = -8000f;
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

