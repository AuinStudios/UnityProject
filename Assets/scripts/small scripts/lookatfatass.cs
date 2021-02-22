using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatfatass : MonoBehaviour
{
    public GameObject pressed;

    [SerializeField] [Range(0.1f, 10f)] float lerptime;
    [SerializeField] Vector3[] mypositions;
    int poseindex = 0;

    int length;

    float t = 0f;

    private void Update()
    {
        if (pressed.transform.position.y == -1.2f)
        {
          transform.position = Vector3.Lerp(transform.position, mypositions[poseindex], lerptime * Time.deltaTime);


            t = Mathf.Lerp(t, 1f, lerptime * Time.deltaTime);
            if (t > .9f)
            {
                t = 0f;
                poseindex++;
                poseindex = (poseindex >= length) ? 0 : poseindex;
        }
        {
            

                
            }
    }



   
    {

       




        }
    }
}
