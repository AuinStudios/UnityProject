using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takecamrotHead : MonoBehaviour
{
    public Transform camrot;
    public Transform pointa;
    public Transform pointb;
    [SerializeField] public float shakevalue = 0.5f;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = camrot.rotation;

        camrot.position= Vector3.Lerp(pointa.position, pointb.position, shakevalue);
       
    }
}
