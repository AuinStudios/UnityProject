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
        {
            // adds force from the transform of the banana looking direction
            rig.AddForce(bananakatana.forward * scriptableobject.meleeAddForce * Time.deltaTime);
            rig.AddForce(Vector3.up  * scriptableobject.upForceMelee * Time.deltaTime);
            float random = Random.Range(-1f, 1f);
            rig.AddTorque(new Vector3(random, random, random) * scriptableobject.upForceMelee);
        }
    }
}
