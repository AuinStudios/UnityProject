using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHeadposition : MonoBehaviour
{
    public Transform parentobject;
    public Transform pos;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = parentobject.rotation;
        transform.position = pos.position;
    }
}
