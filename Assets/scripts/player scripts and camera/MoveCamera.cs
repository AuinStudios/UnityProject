
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject player;
    public Transform playerCam;
    public Transform orientation;
    public float xRotation = 0f;
    public float sensitivity = 50f;
    private float sensMultiplier = 1f;
    
     
   
  
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void  Update()
    {
        
        transform.position = player.transform.position;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime * sensMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime * sensMultiplier;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp( xRotation ,-80, 80);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        orientation.Rotate(Vector3.up * mouseX);
        

        //makes the   camera stop moveing when the game  is paused
        if (Time.timeScale == 0)
        {
            sensitivity = 0;
        }
        if (Time.timeScale == 1)
        {
            sensitivity = 50;
        }
    }
}
