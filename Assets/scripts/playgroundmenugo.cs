using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playgroundmenugo : MonoBehaviour
{
    
    public Animator transition;



    public float transitiontime = 1f;
   

    public void Playgame()
    {
        StartCoroutine(loadlevel(SceneManager.GetActiveScene().buildIndex + 2));
    }





    IEnumerator loadlevel(int loadlevel)
    {
        transition.SetTrigger("start");


        yield return new WaitForSeconds(transitiontime);


        SceneManager.LoadScene(loadlevel);




    }
}

