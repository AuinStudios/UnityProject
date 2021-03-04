
using UnityEngine;

public class ball : MonoBehaviour
{

    public ParticleSystem death;






    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "delete")
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
        Instantiate(death, transform.position, Quaternion.identity);
    }
}
 //if (collision.rigidbody != null)
        
            //collision.rigidbody.AddForc