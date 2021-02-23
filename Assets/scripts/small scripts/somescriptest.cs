using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somescriptest : MonoBehaviour
{
 // variables
    public GameObject equip;
    public float Power = 100.0f;
    public float UpPower = 50.0f;
    public float radius = 60.0f;
    public float damage = 10f;
    public GameObject thing;
    public float range = 100f;
    public float firerate = 3f;
    public float impactforce = 30f;

    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    public GameObject impacteffect;

    private float firetime = 0f;
    Rigidbody rib;
    public int maxammo = 25;
    private int currentammo;
    public float reloadtime = 1f;

    private bool isreloadi = false;
    public Animator animator;





    IEnumerator reload()
    {
        isreloadi = true;
        currentammo = maxammo;
        yield return new WaitForSeconds(reloadtime);
        isreloadi = false;
    }
    void Start()
    {
        currentammo = maxammo;
    }
    // Update is called once per frame
    void Update()
    {


        if (isreloadi)
            return;
        if (currentammo <= 0)
        {
            StartCoroutine(reload());
            return;
        }
        //    butten to fire the gun
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= firetime)
        {
            firetime = Time.time + 1f / firerate;
            Shoot();
        }
    }
    // code to shoot gun
    void Shoot()
    {

     //  Vector3 explosionpos = equip.transform.position;
     //  Collider[] colliders = Physics.OverlapSphere(explosionpos, radius);
     //  foreach (Collider HIT in colliders)
            currentammo--;
        // makes gun go  S H O O T
        muzzleFlash.Play();
        //  shoots wherever ur looking at
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit  , range))
        {// shows in console the fire
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takedamage(damage);

            }


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
    
   // void blow()
   // {
   //
   //
   //
   //     Vector3 explosionpos = equip.transform.position;
   //     Collider[] colliders = Physics.OverlapSphere(explosionpos, radius);
   //     foreach (Collider HIT in colliders)
   //     {
   //         Rigidbody rb = HIT.GetComponent<Rigidbody>();
   //         
   //         if (!HIT.CompareTag("Player"))
   //         {
   //             if (rb != null && !HIT.CompareTag("gun") && !HIT.CompareTag("delete"))
   //             {
   //                 rb.AddExplosionForce(Power, explosionpos, radius, UpPower, ForceMode.Impulse);
   //
   //
   //             }
   //         }
   //        
   //         
   //     }
   // }




    private void OnDrawGizmosSelected()
    {
  #if UNITY_EDITOR
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

#endif
    }
    
}
