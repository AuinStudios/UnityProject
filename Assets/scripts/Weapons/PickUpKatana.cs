using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKatana : MonoBehaviour
{

    public PickupKatnanaEffect e;
    public Meelesystem mmm;
   
    public void Update()
    {
       if(e.auraismegagay == false)
        {
            mmm.enabled = true;
        }
    }
   

   
}
