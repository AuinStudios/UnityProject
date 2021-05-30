
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shotgun : MonoBehaviour
{




    // variables
    // transforms and vectors shit

    public Transform bulletSpawnPoint, resetanimationpos;
    private pickupgun gunboi;
    public Animator anim;
    public Animator temporay;
    public MoveCamera Camerarecoil;
    // ------------------------------------------
    public ParticleSystem muzzleflash;
    public GunsScriptableObject scriptableobject;
    public bool isreloadi = false;
    public PlayerHealthHandler Playerhealth;
    public Shotgun ammotext;
    private float nextimetofire = 1f;
    // --------------------------------------------
    
    public TextMeshProUGUI guntext;

    // -------------------------------------------- 
    IEnumerator Reload()
    {
        anim.GetComponent<Animator>().speed = 1;
        anim.SetBool("isuzistop", false);
        anim.GetComponent<Animator>().enabled = true;
        
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
        
        if (isreloadi)
        {

            anim.GetComponent<Animator>().enabled = true;
        }
        // clamps the  ammo to never go down 0
        guntext.text = Mathf.Clamp((float)scriptableobject.currentAmmo, 0, float.MaxValue).ToString();



        if (Input.GetKeyDown(KeyCode.R) && !gameObject.CompareTag("Cannon"))
        {
            StartCoroutine(Reload());
            anim.SetTrigger("Reload");
        }

        if(scriptableobject.currentAmmo == 0)
        {
            anim.SetBool("isuzistop", false);
        }
        // this is for when the  bullets are 0 to reload
        //if (isreloadi)
        //    return;
        //if (scriptableobject.currentAmmo == 0 )
        //{
        //    StartCoroutine(Reload());
        //    return;
        //}
      
            if (gameObject.CompareTag("uzi") && !Input.GetKey(KeyCode.Mouse0)  &&  (Time.timeScale != 0) && !isreloadi)
            {
            anim.SetBool("isuzistop", false);
            anim.GetComponent<Animator>().playbackTime = 0;
            
            resetanimationpos.localPosition = new Vector3(0.669f, -0.6500001f , 1.946f);
            
            }
        if (Input.GetKey(KeyCode.Mouse0))
        {

            Camerarecoil.uprecoil = 0;
        }
        // shit muzzleflash code
        if (!(Input.GetKey(KeyCode.Mouse0)))
        {
            if (gameObject.CompareTag("flamethrower"))
            {
             muzzleflash.GetComponent<BoxCollider>().enabled = false;
            }
            
            muzzleflash.Stop();
        }
        if (scriptableobject.currentAmmo >= 1)
        {
            muzzleflash.Stop();
        }
        // flamethrower 
        if (Input.GetKey(KeyCode.Mouse0) && !(Playerhealth.Health <= 0) && Time.time >= nextimetofire && ((Time.timeScale != 0) && scriptableobject.currentAmmo >= scriptableobject.bulletCount) && gameObject.CompareTag("flamethrower") && !isreloadi)
        {
            muzzleflash.Play();
            muzzleflash.GetComponent<BoxCollider>().enabled = true;
            scriptableobject.currentAmmo -= 1;
        }
            if (gameObject.GetComponent<Shotgun>().enabled == true)
            {
                guntext.color = new Color(233, 210, 21, 255);
            }
            //  grenadelaunchers + guns etc
        if (  Input.GetKey(KeyCode.Mouse0) && !(Playerhealth.Health <=0) &&Time.time >= nextimetofire &&((Time.timeScale != 0) && scriptableobject.currentAmmo >= scriptableobject.bulletCount) &&!gameObject.CompareTag("flamethrower") && !isreloadi)
        {

            
            
            Camerarecoil.testingsmooth = 0f;
            nextimetofire = Time.time + 1f / scriptableobject.fireRate;
            scriptableobject.currentAmmo -= scriptableobject.bulletCount;
            launchboi();
            if (gameObject.CompareTag("gun") && !isreloadi)
            {
                anim.GetComponent<Animator>().speed = 1;
                anim.SetTrigger("shoot");
                Camerarecoil.uprecoil = 2f ;
            }

                
           


            if (gameObject.CompareTag("Cannon") && !isreloadi )
            {
                
                anim.GetComponent<Animator>().speed = 1;
                temporay.SetTrigger("Shoottank");
                if (isreloadi)
                    return;
                if (scriptableobject.currentAmmo == 0)
                {
                    StartCoroutine(Reload());
                    return;
                }
            }
            if (gameObject.CompareTag("uzi") && !isreloadi )
            {
                anim.GetComponent<Animator>().speed = 4;
                Camerarecoil.uprecoil = 0.3f;
                anim.SetBool("isuzistop", true);
            }
        }
    }

    private void launchboi()
    {
        if (scriptableobject.currentAmmo >= 1)
        {
           muzzleflash.Play();
        }
        
        

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
