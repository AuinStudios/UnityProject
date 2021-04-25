using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKatana : MonoBehaviour
{
    public PickupKatnanaEffect sart;
    public Meelesystem mmm;
    public ParticleSystem effect;
    public void Update()
    {
        
        if(sart.enabled == false )
        {
            effect.Play();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bananakatana"))
        {
            mmm.enabled = true;
        }
        
        
    }

   
}
