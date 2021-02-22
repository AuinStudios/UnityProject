using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpratitle : MonoBehaviour
{
    public float damage = 10f;

    public float range = 1f;

    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    public GameObject impacteffect;
    public float firerate = 10f;
    private float firetime = 0f;

    // Update is called once per frame
    void Update()
    {//    butten to fire the gun
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= firetime ) 
        {
            firetime = Time.time + 1f / firerate;
            Shoot();
        }
    }
    // code to shoot gun
    void Shoot()
    {// makes gun go  S H O O T
        muzzleFlash.Play();
        //  shoots wherever ur looking at
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {// shows in console the fire
            Debug.Log(hit.transform.name);
            // checks if the target took damage or not
            notuseing Target = hit.transform.GetComponent<notuseing>();
            if (Target != null)
            {// makes target take damage
                Target.Takedamage(damage);
            }
            // code for praticle to show every time u click
            GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
            // destorys  praticles that despawned so it doesnt lag the game
            Destroy(impactGO, 1f);
        }
    }

}
