using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{// variables
    public float damage = 10f;
  public  GunsScriptableObject scriptableobject;
   
    public Camera fpscam;

    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI guntext;
    public GameObject impacteffect;

    private bool isreloadi = false;
    private float nextimetofire;
    public Animator animator;

   IEnumerator reload()
    {
        isreloadi = true;
        scriptableobject.currentAmmo = scriptableobject.maxAmmo;
        yield return new WaitForSeconds(scriptableobject.reloadTime);
        isreloadi = false;
    }

  
     void Start()
    {
        scriptableobject.currentAmmo = scriptableobject.maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        guntext.text = Mathf.Clamp((float)scriptableobject.currentAmmo, 0, float.MaxValue).ToString();


        if (isreloadi)
            return;
       if  (scriptableobject.currentAmmo <= 0)
        {
            StartCoroutine(reload());
            return;
        }
        //    butten to fire the gun
        if (Input.GetKeyDown(KeyCode.Mouse0) &&Time.time >=  nextimetofire) 
        {
            nextimetofire = Time.time + 1f / scriptableobject.fireRate;
            Shoot();
        }
    }

    // code to shoot gun
    void Shoot()
    {
        scriptableobject.currentAmmo--;
        // makes gun go  S H O O T
        muzzleFlash.Play();
        //  shoots wherever ur looking at
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, scriptableobject.range))
        {// shows in console the fire
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takedamage(damage);
            }
           
          
             if (hit.rigidbody != null)
             {
                hit.rigidbody.AddForce(-hit.normal * scriptableobject.impactForce);



            


             }
            
            // makes impact force to push the block
           
            // checks if the target took damage or not
            notuseing Target = hit.transform.GetComponent<notuseing>();
            if (Target != null)
            {// makes target take damage
                Target.Takedamage(damage);
            }












    // code for praticle to show every time u click
    GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
            // destorys  praticles that despawned so it doesnt lag the game
            Destroy(impactGO, 3f);



        }
    }
}   
   



    
