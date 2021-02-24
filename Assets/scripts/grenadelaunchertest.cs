using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class grenadelaunchertest : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject grenade;
    public bombpickup bombboi;
    public float range = 15f;
    public GunsScriptableObject scriptableobject;
    public bool isreloadi = false;
    private float nextimetofire = 1f;
   
    
    
    public TextMeshProUGUI guntext;

    
    

    IEnumerator Reload()
    {
        isreloadi = true;
        scriptableobject.currentammo = scriptableobject.maxammo;
        yield return new WaitForSeconds(scriptableobject.Reloadtime);
        isreloadi = false;
    }





    // Start is called before the first frame update
    void Start()
    {
        scriptableobject.currentammo = scriptableobject.maxammo;
        

    }

    // Update is called once per frame
    void Update()
    {


        guntext.text = Mathf.Clamp((float)scriptableobject.currentammo, 0, float.MaxValue).ToString();

       

       



        if (isreloadi)
            return;
        if (scriptableobject.currentammo == 0 )
        {
            StartCoroutine(Reload());
            return;
        }

       

        if (bombboi == enabled && Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextimetofire) 
        {
            nextimetofire = Time.time + 1f / scriptableobject.firerate;
            
            launchboi();

            scriptableobject.currentammo -= 1;


        }
    }
    private void launchboi() 
    {
        GameObject grenadespawn = Instantiate(grenade, spawnpoint.position, spawnpoint.rotation);
        grenadespawn.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * range, ForceMode.Impulse);
    }
}
