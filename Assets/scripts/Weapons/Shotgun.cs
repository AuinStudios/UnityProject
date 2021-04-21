
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shotgun : MonoBehaviour
{




    // variables
    // transforms and vectors shit
    
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    [Range(1,30)]
    public int bulletCount = 1;
    [Range(0.01f, 0.25f)]
    public float spreadAmount = 0.01f;
    [Range(1.0f, 1.5f)]
    public float bulletSpeedVariation = 1.0f;

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
        scriptableobject.currentammo = scriptableobject.maxammo;
        yield return new WaitForSeconds(scriptableobject.Reloadtime);
        isreloadi = false;
    }

    // ----------------------------------------------




    void Awake()
    {
        scriptableobject.currentammo = scriptableobject.maxammo;

        if (bulletSpawnPoint == null)
        {
            bulletSpawnPoint = this.transform;
        }
    }
    // ---------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {

        // clamps the  ammo to never go down 0
        guntext.text = Mathf.Clamp((float)scriptableobject.currentammo, 0, float.MaxValue).ToString();



        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }



        if (isreloadi)
            return;
        if (scriptableobject.currentammo == 0)
        {
            StartCoroutine(Reload());
            return;
        }
       

        if (gunboi == enabled && Input.GetKey(KeyCode.Mouse0) && Time.time >= nextimetofire && scriptableobject.currentammo >= bulletCount)
        {
            nextimetofire = Time.time + 1f / scriptableobject.firerate;

            launchboi();

            scriptableobject.currentammo -= bulletCount;


        }
    }

    private void launchboi()
    {
        muzzleflash.Play();

        for (int i = 0; i < bulletCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(bulletSpawnPoint.position.x - spreadAmount, bulletSpawnPoint.position.x + spreadAmount),
                                                Random.Range(bulletSpawnPoint.position.y - spreadAmount, bulletSpawnPoint.position.y + spreadAmount),
                                                Random.Range(bulletSpawnPoint.position.z - spreadAmount, bulletSpawnPoint.position.z + spreadAmount));

            GameObject newBullet = Instantiate(bullet, spawnPosition, bulletSpawnPoint.gameObject.transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * scriptableobject.Range * Random.Range(1.0f, bulletSpeedVariation), ForceMode.Impulse);
        }
    }

    // ---------------------------------------------------------------------------------------------------
}
