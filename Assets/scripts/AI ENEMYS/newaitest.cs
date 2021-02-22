using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class newaitest : MonoBehaviour
{
    //variables for ai
    public Transform player;
    public float speed = 7f;
    Rigidbody rig;
    public Transform lookatplayer;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {// gets the rigidbody into the variable
        rig = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // makes the ai go to the player
        Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
        rig.MovePosition(pos);

{
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
    }


     


   
    
}   
