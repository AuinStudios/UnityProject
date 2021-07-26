using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test3 : MonoBehaviour
{


    public float lookradius = 10f;

    public Transform target;
    private GameObject Attackcol;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        Attackcol = GameObject.Find("attackcol");
       // target = Playermanager.instance.Player.transform;
       
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookradius)
        {
            agent.SetDestination(target.position);
        }

        if (distance <= agent.stoppingDistance)
        {
            Attackcol.SetActive(true);
            facetarget();
        }
        else
            Attackcol.SetActive(false);
    }

    void facetarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookradius);
    }



}  
