using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    public int timer = 4;
    public float firerate = 1f;
    private float nextimetofire = 0.1f;
    public GameObject Shield;
    public Transform gameobjectspawnshield;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K) && Time.time >= nextimetofire)
        {
                nextimetofire = Time.time + 1f / firerate;
            Instantiate(Shield);
            
            Shield.transform.position = gameobjectspawnshield.transform.position;

            
        }
          Destroy(Shield.gameObject, timer);

        
    }
        

}

