using UnityEngine;

public class grapplegun : MonoBehaviour
{
    // variables
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, Camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    // line render 
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    // gets inputs for clicking to start and  not clicking to stop
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    //Called after Update
    void LateUpdate()
    {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple()
    {// variable to detect to hit
        RaycastHit hit;
        //  it hits where the camera looks at and which layer is grabbleable
        if (Physics.Raycast(Camera.position, Camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.01f;
            joint.minDistance = distanceFromPoint * 0.01f;

            //Adjust these values to fit your game.
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>///
    //  when the grapple stops it goes back to its original position and destorys the line render
    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }
    // variable for currentgrapple pos
    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
