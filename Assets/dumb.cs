using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumb : MonoBehaviour
{

    public GameObject lol;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(lol.transform.position);
        gameObject.transform.Translate(lol.transform.position * 0.1f * Time.deltaTime);

    }
}
