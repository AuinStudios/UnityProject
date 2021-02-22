using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transtistion : MonoBehaviour
{
    public Animator transition;

    public float transitiontime = 1.0f;



    public void OnTriggerStay(Collider other)
    {
         if (other.gameObject.CompareTag("Player"))
        {


            StartCoroutine(loadlevel(SceneManager.GetActiveScene().buildIndex +1));
            
        }
    }


   

    IEnumerator loadlevel(int loadlevel)
    {
        transition.SetTrigger("start");


        yield return new WaitForSeconds(transitiontime);


        SceneManager.LoadScene(loadlevel);




    }

}
