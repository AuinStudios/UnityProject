using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunfluidmovement : MonoBehaviour
{
        //variables

        public float intensity;
        public float smooth;
    public PlayerHealthHandler Playerhealth;
        private Quaternion originalrotation;
      

        // -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Update is called once per frame



private void Start()
{
    originalrotation = transform.rotation;
}


  private void Update()
  {

    if (!(Playerhealth.Health <= 0))
    {
      FluidUpdate();
    }
  }




 private void FluidUpdate()
{
    float t_xmouse = Input.GetAxis("Mouse X");

     float t_ymouse = Input.GetAxis("Mouse Y");

          



        Quaternion xrotation = Quaternion.AngleAxis(-intensity * t_xmouse, Vector3.up);

            Quaternion yrotation = Quaternion.AngleAxis(intensity * t_ymouse, Vector3.right);

                            
                 
                           Quaternion target_rotation = originalrotation* xrotation  * yrotation ;

 
                              transform.localRotation = Quaternion.Lerp(transform.localRotation, target_rotation, Time.deltaTime * smooth);
}

}


