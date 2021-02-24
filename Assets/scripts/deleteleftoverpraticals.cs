using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteleftoverpraticals : MonoBehaviour
{
    public float timer = 1f;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "explosion(Clone)")
        {
          Destroy(gameObject, timer);
        }
        
    }
}
