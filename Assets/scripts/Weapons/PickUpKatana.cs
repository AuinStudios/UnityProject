using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKatana : MonoBehaviour
{

    public PickupKatnanaEffect e;
    public Meelesystem mmm;
    public PlayerHealthHandler Health;
    public void Update()
    {
        if(Health.Health <= 0)
        {
            mmm.enabled = false;
        }
       if(e.auraismegagay == false)
        {
            mmm.enabled = true;
        }
    }
   

   
}
