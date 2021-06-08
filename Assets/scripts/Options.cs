using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    public GameObject menu;
    public GameObject options;
    public   float slidernumber = 0;
    public int maxvalue = 80;
    public Slider slidervalue;
    // Update is called once per frame
    void Update()
    {
       slidernumber = Mathf.Clamp((int)slidernumber, 0, maxvalue);
       PlayerPrefs.SetFloat("slidernumber", slidervalue.value);
      
    }

    public void disableothers()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }
    public void disableop()
    {
        if(EventSystem.current.alreadySelecting == true)
        {
            EventSystem.current.SetSelectedGameObject(null);

        }
       
        menu.SetActive(true);
        options.SetActive(false);
    }
    

    public void slider(float test3)
      {
    slidernumber = test3;     
    
    }
}
