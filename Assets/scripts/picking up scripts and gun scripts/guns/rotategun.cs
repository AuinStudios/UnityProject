
using UnityEngine;

public class rotategun : MonoBehaviour
{

    public grapplegun grappling;

    private Quaternion desiredRotation;
    private float rotationSpeed = 5f;

    void Update()
    {// rotates the gun when its grappleing
        if (!grappling.IsGrappling())
        {
            desiredRotation = transform.parent.rotation;
        }
        else
        {//  rotates towards the  end tip of the  line
            desiredRotation = Quaternion.LookRotation(grappling.GetGrapplePoint() - transform.position);
        }
       // not sure right now ill try lookin in it later
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }

}