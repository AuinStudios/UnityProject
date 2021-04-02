using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Grenadelauncher : MonoBehaviour
{
    // variables
    // transforms and vectors shit
    public Transform spawnpoint;
    public GameObject bullet;
    public bombpickup bomboi;
    
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



        if (bomboi == enabled && Input.GetKey(KeyCode.Mouse0) && Time.time >= nextimetofire)
        {
            nextimetofire = Time.time + 1f / scriptableobject.firerate;

            launchboi();

            scriptableobject.currentammo -= 1;


        }
    }
    private void launchboi()
    {
        muzzleflash.Play();
        GameObject grenadespawn = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
        grenadespawn.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * scriptableobject.Range, ForceMode.Impulse);

    }
    // ---------------------------------------------------------------------------------------------------
}
