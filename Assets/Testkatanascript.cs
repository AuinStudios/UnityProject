using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testkatanascript : MonoBehaviour
{
    public GunsScriptableObject scriptableobject;
   public   Rigidbody rig;
    
    public Transform bananakatana;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("bananakatana"))
        {// adds force from the transform of the banana looking direction
            rig.AddForce(bananakatana.forward * scriptableobject.meeeleaddforce);
            rig.AddForce(Vector3.up  * scriptableobject.upforcemeele);
            float random = Random.Range(-1f, 1f);
            rig.AddTorque(new Vector3(random, random, random) * scriptableobject.upforcemeele);
        }
    }
}
