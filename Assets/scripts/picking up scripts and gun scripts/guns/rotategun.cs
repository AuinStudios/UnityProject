
using UnityEngine;

public class rotategun : MonoBehaviour
{

    public void Update()
    {
        transform.Rotate(Vector3.right * 0.1f * Time.deltaTime);
    }

}