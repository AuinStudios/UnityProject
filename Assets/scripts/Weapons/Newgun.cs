using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Newgun : MonoBehaviour
{
    // variables
    // transforms and vectors shit
    public Transform spawnpoint;
    public GameObject bullet;
    public pickupgun gunboi;

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
        isreloadi = true;
        scriptableobject.currentAmmo = scriptableobject.maxAmmo;
        yield return new WaitForSeconds(scriptableobject.reloadTime);
        isreloadi = false;
    }

    // ----------------------------------------------




    void Start()
    {
        scriptableobject.currentAmmo = scriptableobject.maxAmmo;
        

    }
    // ---------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {

        // clamps the  ammo to never go down 0
        guntext.text = Mathf.Clamp((float)scriptableobject.currentAmmo, 0, float.MaxValue).ToString();







        if (isreloadi)
            return;
        if (scriptableobject.currentAmmo == 0)
        {
            StartCoroutine(Reload());
            return;
        }



        if (gunboi == enabled && Input.GetKey(KeyCode.Mouse0) && Time.time >= nextimetofire)
        {
            nextimetofire = Time.time + 1f / scriptableobject.fireRate;

            launchboi();

            scriptableobject.currentAmmo -= 1;


        }
    }
    private void launchboi()
    {
        muzzleflash.Play();
        GameObject grenadespawn = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
        grenadespawn.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * scriptableobject.range, ForceMode.Impulse);
        
    }
    // ---------------------------------------------------------------------------------------------------
}

