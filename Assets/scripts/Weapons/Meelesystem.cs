using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meelesystem : MonoBehaviour
{
    public Animator animateboi;
    public Transform ye;
   public  Rigidbody rig;
    public GunsScriptableObject scriptableobject;
    public Animator camerashake;


  

    public void Start()
    {// gets the  animator
        animateboi = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
       
        

        // transform thing for bannaa katana
        gameObject.transform.position = ye.transform.position;

        // to start the animation
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
           animateboi.SetTrigger("start"  );
             animateboi.SetBool("isidle", true);

            
        }
        
        
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject  && !collision.gameObject.CompareTag("Player")&& !collision.gameObject.CompareTag("Ground"))
        {
            camerashake.SetBool("Shakeorno", true);
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject)
        {
            camerashake.SetBool("Shakeorno" , false);
        }
    }
}
