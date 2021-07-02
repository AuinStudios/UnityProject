using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    public GameObject menu;
    public GameObject options;
    public GameObject lighting;
    public   float slidernumber = 0;
    public int maxvalue = 80;
    public TextMeshProUGUI textui;
    public Slider slidervalue;
    public int boolcounter;
    // Update is called once per frame
    void Update()
    {
       slidernumber = Mathf.Clamp((int)slidernumber, 0, maxvalue);
       PlayerPrefs.SetFloat("slidernumber", slidervalue.value);
        if (lighting.GetComponent<Toggle>().isOn == true)
        {
        
            PlayerPrefs.SetInt("boolcounter", boolcounter = 1);

        }
        else if (lighting.GetComponent<Toggle>().isOn == false)
        {
         PlayerPrefs.SetInt("boolcounter", boolcounter = 0);
        }
           
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
       textui.text = Mathf.Clamp((int)slidernumber, 0, int.MaxValue).ToString();
        
    }

    public void togglebetterlighting(bool isenabeld)
    {
        lighting.GetComponent<Toggle>().isOn = isenabeld;
        if (lighting.GetComponent<Toggle>().isOn == true)
        { 
            
            isenabeld = true;
            Debug.Log("beans");
          
        }
        else
            isenabeld = false;
       
        Debug.Log("nobeans");

    }
}
