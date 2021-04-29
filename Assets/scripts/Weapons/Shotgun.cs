﻿
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shotgun : MonoBehaviour
{




    // variables
    // transforms and vectors shit
   
    public Transform bulletSpawnPoint;
    private pickupgun gunboi;
    public Animator anim;
    // ------------------------------------------
    public ParticleSystem muzzleflash;
    public GunsScriptableObject scriptableobject;
    public bool isreloadi = false;
    private float nextimetofire = 1f;
    // --------------------------------------------
    
    public TextMeshProUGUI guntext;

    // -------------------------------------------- 
    IEnumerator Reload()
    {
        anim.SetTrigger("Reload");
        isreloadi = true;
        scriptableobject.currentAmmo = scriptableobject.maxAmmo;
        yield return new WaitForSeconds(scriptableobject.reloadTime);
        isreloadi = false;
    }

    // ----------------------------------------------




    void Awake()
    {
        scriptableobject.currentAmmo = scriptableobject.maxAmmo;

        if (bulletSpawnPoint == null)
        {
            bulletSpawnPoint = this.transform;
        }

        gunboi = this.GetComponent<pickupgun>();
    }


    // ---------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        
        // clamps the  ammo to never go down 0
        guntext.text = Mathf.Clamp((float)scriptableobject.currentAmmo, 0, float.MaxValue).ToString();



        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }



        if (isreloadi)
            return;
        if (scriptableobject.currentAmmo == 0)
        {
            StartCoroutine(Reload());
            return;
        }
       

        if (gunboi == enabled && Input.GetKey(KeyCode.Mouse0) && Time.time >= nextimetofire && scriptableobject.currentAmmo >= scriptableobject.bulletCount)
        {
            nextimetofire = Time.time + 1f / scriptableobject.fireRate;
            scriptableobject.currentAmmo -= scriptableobject.bulletCount;
            launchboi();
            if (gameObject.CompareTag("uzi"))
            {
                anim.SetTrigger("Uzi");
                    
            }
            if (!gameObject.CompareTag("uzi"))
            {
              anim.SetTrigger("shoot");
            }
            
            
        }
    }

    private void launchboi()
    {
        muzzleflash.Play();

        for (int i = 0; i < scriptableobject.bulletCount; i++)
        {
            Vector3 spawnPosition;

            if (scriptableobject.canSpread == true)
            {
                spawnPosition = new Vector3(Random.Range(bulletSpawnPoint.position.x - scriptableobject.spreadAmount, bulletSpawnPoint.position.x + scriptableobject.spreadAmount),
                                            Random.Range(bulletSpawnPoint.position.y - scriptableobject.spreadAmount, bulletSpawnPoint.position.y + scriptableobject.spreadAmount),
                                            Random.Range(bulletSpawnPoint.position.z - scriptableobject.spreadAmount, bulletSpawnPoint.position.z + scriptableobject.spreadAmount));
                
                GameObject newBullet = (GameObject)Instantiate(scriptableobject.bullet, spawnPosition, bulletSpawnPoint.gameObject.transform.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * scriptableobject.range * Random.Range(1.0f, scriptableobject.bulletSpreadVariation), ForceMode.Impulse);
            }
            else
            {
                spawnPosition = new Vector3(Random.Range(bulletSpawnPoint.position.x, bulletSpawnPoint.position.x),
                                            Random.Range(bulletSpawnPoint.position.y, bulletSpawnPoint.position.y),
                                            Random.Range(bulletSpawnPoint.position.z, bulletSpawnPoint.position.z));

                GameObject newBullet = (GameObject)Instantiate(scriptableobject.bullet, spawnPosition, bulletSpawnPoint.gameObject.transform.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * scriptableobject.range, ForceMode.Impulse);
            }
        }
    }

    // ---------------------------------------------------------------------------------------------------
}
