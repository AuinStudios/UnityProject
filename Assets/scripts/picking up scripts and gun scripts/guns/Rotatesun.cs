
using UnityEngine;

public class Rotatesun : MonoBehaviour
{

    public void Update()
    {
        transform.Rotate(Vector3.right * 0.1f * Time.deltaTime);
    }

}