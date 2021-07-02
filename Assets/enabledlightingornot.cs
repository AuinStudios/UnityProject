using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enabledlightingornot : MonoBehaviour
{
    public GameObject disablelightingeffects;
    public Options op;
    public int enabledd;
    // Start is called before the first frame update
    void Start()
    {
        enabledd = PlayerPrefs.GetInt("boolcounter");
    }

    // Update is called once per frame
    void Update()
    {
       
        if(enabledd == 1)
        {
            disablelightingeffects.SetActive(true);
        }
        if(enabledd == 0)
        {
            disablelightingeffects.SetActive(false);
        }
    }
}
