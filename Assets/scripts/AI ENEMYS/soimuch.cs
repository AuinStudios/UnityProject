using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class soimuch : MonoBehaviour
{
    public Transform pp;
    public LayerMask whatisplayer;
    public float health = 100f;
    //attack bitch
    public float sightrange , attackrange;
    public bool playerinsightrange, playerinattackrange;
    public float timebetweenattacks;
    bool alreadyattacked;
    public GameObject bullet;

    public float time = 3f;
    private void Update()
    {
        
        playerinsightrange = Physics.CheckSphere(transform.position, sightrange, whatisplayer);
        playerinattackrange = Physics.CheckSphere(transform.position, attackrange, whatisplayer);

        if (playerinsightrange && playerinattackrange) attack();

    }

    private void Awake()
    {
        pp = GameObject.Find("Player").transform;
    }

    public void attack()
    {

        facetarget();

        if (!alreadyattacked)
        {
            Rigidbody rbe = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rbe.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rbe.AddForce(transform.up * 8f, ForceMode.Impulse);


            



            alreadyattacked = true;
            Invoke(nameof(resetattack), timebetweenattacks);
        }


    }
    private void resetattack()
    {
        alreadyattacked = false;
    }

    void facetarget()
    {
        Vector3 direction = (pp.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5f);
    }






    public void destorynoob()
    {
        if(gameObject.name == "bullet")
        {
            Destroy(gameObject, time);
        }
    }

    public void takedamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(destoryboi), 0.5f);
        

        

        
    }
    private void destoryboi()
    {
        Destroy(gameObject);
    }
}
