using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseitem : MonoBehaviour
{
    public string gunName = "";

    public virtual void ShootGun()
    {
        Debug.Log("Shooting gun...");
    }
}
