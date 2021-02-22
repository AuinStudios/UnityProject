using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : baseitem
{
    public grapplegun grapplegun;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ShootGun();
        }
    }

    public override void ShootGun()
    {
        base.ShootGun();

        Debug.Log("shooting grapple hook...");
    }
}
