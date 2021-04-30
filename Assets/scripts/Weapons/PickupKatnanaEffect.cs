using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKatnanaEffect : MonoBehaviour
{
   
    public  bool auraismegagay = false;
    public float spin = -10f;
    public Animator auraisgaywithme;
    public ParticleSystem pp;

    // Update is called once per frame
    public  void Update()
    {
        gameObject.transform.Rotate(0f, 0, spin * Time.deltaTime);

        if (auraismegagay == false)
        {

            Instantiate(pp, transform.position, transform.rotation);


        }
     

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
 

            auraisgaywithme.SetTrigger("blow");
        }
    }
}
