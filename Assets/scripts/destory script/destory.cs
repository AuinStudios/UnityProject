using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory : MonoBehaviour
{
    //variables
    public GameObject destoryed;

    void OnMouseDown()
    {// destorys the block i think not sure
        Instantiate(destoryed, transform.position, transform.rotation);
        // breaks the original gameobject and replaces it with the craceked version
        Destroy(gameObject);
    }

}
