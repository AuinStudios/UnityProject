using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHeadposition : MonoBehaviour
{
    public Transform tankposhead;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tankposhead.position;
    }
}
