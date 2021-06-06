using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{

    public int selectedweapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        Selectedweapon();
    }

    // Update is called once per frame
    void Update()
    {


        int previousselectedweapon = selectedweapon;

        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && !Input.GetKey(KeyCode.R) && !Input.GetKey(KeyCode.Mouse0)) 
        {
            if (selectedweapon >= transform.childCount - 1)
                selectedweapon = 0;
            else
                selectedweapon++;
        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0f && !Input.GetKey(KeyCode.R) && !Input.GetKey(KeyCode.Mouse0))
        {
            if (selectedweapon <= 0)
                selectedweapon = transform.childCount - 1;
            else
                selectedweapon--;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1)&&  !Input.GetKey(KeyCode.Mouse0))
        {
            selectedweapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) &&   !Input.GetKey(KeyCode.Mouse0) && transform.childCount >= 2)
        {
            selectedweapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)&& !Input.GetKey(KeyCode.Mouse0) && transform.childCount >= 3)
        {
            selectedweapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)&&  !Input.GetKey(KeyCode.Mouse0) && transform.childCount >= 4)
        {
            selectedweapon = 3;
        }



        if(previousselectedweapon != selectedweapon)
        {
            Selectedweapon();
        }

      
    }

    public void Selectedweapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if( i == selectedweapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    


}
