using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitrigger : MonoBehaviour
{
    // This is Obselete and not longer in use

    /**
     
    [SerializeField] [Range(1f, 10f)] float lerptime;
    [SerializeField]
    public Vector3[] mypositions;
    int poseindex = 0;

    int length;

    float t = 0f;



    private void Start()
    {
        length = mypositions.Length;
    }
 
  
    private void OnTriggerStay(Collider other)
    { 
        if (gameObject.name == "door")
        {
            transform.position = Vector3.Lerp(transform.position, mypositions[poseindex], lerptime * Time.deltaTime);

            t = Mathf.Lerp(t, 1f, lerptime * Time.deltaTime);
            if (t > .9f)
            {
                t = 0f;
                poseindex++;
                poseindex = (poseindex >= length) ? 0 : poseindex;
            }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (gameObject.name == "plate")  

            transform.position = Vector3.Lerp(transform.position, mypositions[poseindex], lerptime * Time.deltaTime);


        t = Mathf.Lerp(t, 1f, lerptime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            poseindex++;
            poseindex = (poseindex >= length) ? 0 : poseindex;
        }
    }

     */
}
