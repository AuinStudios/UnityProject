using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunaddforce : MonoBehaviour
{
    public GunsScriptableObject scriptableobject;
    public Rigidbody rig;
        public Transform bulletgun;
    public  void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("bullet"))
        {

            // adds force from the transform of the banana looking direction
            rig.AddForce(bulletgun.forward * scriptableobject.bulletForce * Time.deltaTime);
            rig.AddForce(bulletgun.up * scriptableobject.bulletForce * Time.deltaTime);


        }
    }
}