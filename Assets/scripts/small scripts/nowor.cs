using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nowor : MonoBehaviour
{
    
    public Transform target;
    Rigidbody ri;

    public float range;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);


        if (distance <= range)
        {
            transform.position = new Vector3(-40, 6, 34);
        }


        if (distance >= range)
        {
            transform.position = new Vector3(-40, 2, 34);
        }
    }



    


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
