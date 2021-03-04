using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    
    public Rigidbody rig;
    public Transform player;
    private float forwardspeed = 300f;
    private float backwards = -300f;
    private float right = 300f;
    private float left = -300f;
    public GameObject GFX;
    public float jumpower = 60000f;
    public bool isgroundedboi;
    private float dontjump = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GFX.transform.position ;

    pllayermovement();
        
    }



    public void OnTriggerExit(Collider other2)
    {
        isgroundedboi = false;
        
            
        
            
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("groundballgame"))
        {
            isgroundedboi = true;
        }
       
    }


    public void pllayermovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rig.AddForce(player.forward * forwardspeed * Time.deltaTime , ForceMode.Impulse);
            
            
        }

        




        if (Input.GetKey(KeyCode.S))
        {
            rig.AddForce(player.forward * backwards * Time.deltaTime, ForceMode.Impulse);
            
        }


        if (Input.GetKey(KeyCode.D))
        {
            rig.AddForce(player.right * right * Time.deltaTime , ForceMode.Impulse);
           
        }



        if (Input.GetKey(KeyCode.A))
        {
            rig.AddForce(player.right * left  * Time.deltaTime, ForceMode.Impulse);
            
        }

        
       

        if (!isgroundedboi)
        {
            rig.AddForce(player.up * dontjump * Time.deltaTime, ForceMode.Impulse);

            
            



        }
        

        if (isgroundedboi  && (Input.GetKeyDown(KeyCode.Space)))
        {
            rig.AddForce(player.up * jumpower * Time.deltaTime, ForceMode.Impulse);

        }
    }





    



}
