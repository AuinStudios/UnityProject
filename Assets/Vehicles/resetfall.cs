using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetfall : MonoBehaviour
{

    public Rigidbody rig;
    public Tank a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(a.enabled== true && Input.GetKeyDown(KeyCode.Y))
        {
            rig.isKinematic = true;
        }
    }
}
