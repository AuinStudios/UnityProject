using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continuegame : MonoBehaviour
{

    public GameObject menu, background , continuee;
    public Animator pause;
   public void continuegame()
    {
        continuee.SetActive(false);
        pause.GetComponent<Animator>().enabled = true;
        background.GetComponent<CanvasGroup>().alpha = 0;
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
       
    


}
