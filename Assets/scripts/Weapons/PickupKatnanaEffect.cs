using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKatnanaEffect : MonoBehaviour
{
   
    public float spin = -10f;
    public Animator auraisgaywithme;
 
    // Update is called once per frame
    public  void Update()
    {
        gameObject.transform.Rotate(0f, 0, spin * Time.deltaTime);
      
       

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            auraisgaywithme.SetTrigger("blow");
        }
    }
}
