using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafov : MonoBehaviour
{
    public Camera fov;
    // Start is called before the first frame update
    void Start()
    {
        fov = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Camera>().fieldOfView = fov.fieldOfView;
    }
}
