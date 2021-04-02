
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shotgun : MonoBehaviour
{




    // variables
    // transforms and vectors shit
    public Transform spawnpoint , twospawnpoint , threespawnpoint , fourspawnpoint;
    public GameObject bullet , twobullet , threebuullet , fourbullet;
    public pickupgun gunboi;
    private bombpickup bombboi;
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
        scriptableobject.currentammo = scriptableobject.maxammo;
        yield return new WaitForSeconds(scriptableobject.Reloadtime);
        isreloadi = false;
    }

    // ----------------------------------------------




    void Start()
    {
        scriptableobject.currentammo = scriptableobject.maxammo;


    }
    // ---------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {

        // clamps the  ammo to never go down 0
        guntext.text = Mathf.Clamp((float)scriptableobject.currentammo, 0, float.MaxValue).ToString();







        if (isreloadi)
            return;
        if (scriptableobject.currentammo == 0)
        {
            StartCoroutine(Reload());
            return;
        }



        if (gunboi == enabled && Input.GetKey(KeyCode.Mouse0) && Time.time >= nextimetofire)
        {
            nextimetofire = Time.time + 1f / scriptableobject.firerate;

            launchboi();

            scriptableobject.currentammo -= 4;


        }
    }
    private void launchboi()
    {
        muzzleflash.Play();
        GameObject grenadespawn = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
        GameObject grenadespawn2 = Instantiate(twobullet, twospawnpoint.position, twospawnpoint.rotation);
        GameObject grenadespawn3 = Instantiate(threebuullet, threespawnpoint.position, threespawnpoint.rotation);
        GameObject grenadespawn4 = Instantiate(fourbullet, fourspawnpoint.position, fourspawnpoint.rotation);
        grenadespawn.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * scriptableobject.Range, ForceMode.Impulse);
        grenadespawn2.GetComponent<Rigidbody>().AddForce(twospawnpoint.forward * scriptableobject.Range, ForceMode.Impulse);
        grenadespawn3.GetComponent<Rigidbody>().AddForce(threespawnpoint.forward * scriptableobject.Range, ForceMode.Impulse);
        grenadespawn4.GetComponent<Rigidbody>().AddForce(fourspawnpoint.forward * scriptableobject.Range, ForceMode.Impulse);
    }
    // ---------------------------------------------------------------------------------------------------
}
