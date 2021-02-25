using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meelesystem : MonoBehaviour
{
    public Animator animateboi;
    public Transform ye;
   public  Rigidbody rig;
    public ParticleSystem effects;
    public GunsScriptableObject scriptableobject;
    


  

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
           

            
        }
        

        
    }
}
