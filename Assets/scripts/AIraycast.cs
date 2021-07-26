using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AIraycast : MonoBehaviour
{
    RaycastHit hit;

    [Range(5, 20)]
    public int maxRays = 10;

    public List<Vector3> directions = new List<Vector3>();

    [Range(2.0f, 10.0f)]
    public float maxDistance = 5.0f;

    private void Awake()
    {
        directions = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        directions.Clear();
        for (int directionIndex = 0; directionIndex < maxRays; directionIndex++)
        {
            directions.Add(Vector3.left * (directionIndex * -0.1f) / (maxRays * 0.1f));
        }

        for (int rayIndex = 0; rayIndex < maxRays; rayIndex++)
        {
            Vector3 dir;
            if (directions[rayIndex].x > 0.5f)
            {
                dir = (transform.forward / directions[rayIndex].x) + transform.right;//transform.right + directions[rayIndex];
            }
            else
            {
                dir = (transform.forward / directions[rayIndex].x * -0.1f) + transform.right;//transform.right + directions[rayIndex];
            }

            bool ray = Physics.Raycast(transform.position, dir, out hit, maxDistance);

            if (ray == true)
            {
                Debug.DrawRay(transform.position, dir * maxDistance, Color.red);
            }
            else
            {
                Debug.DrawRay(transform.position, dir * maxDistance, Color.green);
            }
        }



    }



    //RaycastHit hit;
    //
    //[Range(5, 20)]
    //public int maxRays = 10;
    //
    //public List<Vector3> directions = new List<Vector3>();
    //
    //[Range(2.0f, 10.0f)]
    //public float maxDistance = 5.0f;
    //
    //private void Awake()
    //{
    //    directions = new List<Vector3>();
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    directions.Clear();
    //    for (int directionIndex = 0; directionIndex < maxRays; directionIndex++)
    //    {
    //        directions.Add(Vector3.left * (directionIndex * -0.1f) / (maxRays * 0.1f));
    //    }
    //
    //    for (int rayIndex = 0; rayIndex < maxRays; rayIndex++)
    //    {
    //        Vector3 dir;
    //        if (directions[rayIndex].x > 0.5f)
    //        {
    //            dir = (transform.forward / directions[rayIndex].x) + transform.right;//transform.right + directions[rayIndex];
    //        }
    //        else
    //        {
    //            dir = (transform.forward / directions[rayIndex].x * -0.1f) + transform.right;//transform.right + directions[rayIndex];
    //        }
    //
    //        bool ray = Physics.Raycast(transform.position, dir, out hit, maxDistance);
    //
    //        if (ray == true)
    //        {
    //            Debug.DrawRay(transform.position, dir * maxDistance, Color.red);
    //        }
    //        else
    //        {
    //            Debug.DrawRay(transform.position, dir * maxDistance, Color.green);
    //        }
}  //    }
