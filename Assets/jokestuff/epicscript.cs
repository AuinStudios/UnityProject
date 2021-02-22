using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class epicscript : MonoBehaviour
{

    public float aura = 0f;



    // Start is called before the first frame update
    void Start()
    {
        if (aura == 0f)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
