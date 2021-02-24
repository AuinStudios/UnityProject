using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadelaunchertest : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject grenade;
    public bombpickup bombboi;
    public float range = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bombboi == enabled && Input.GetKeyDown(KeyCode.Mouse0))
        {
            launchboi();
        }
    }
    private void launchboi() 
    {
        GameObject grenadespawn = Instantiate(grenade, spawnpoint.position, spawnpoint.rotation);
        grenadespawn.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * range, ForceMode.Impulse);
    }
}
