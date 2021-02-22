using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    public Animator transition;



    public float transitiontime = 1f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Playgame()
    {
        StartCoroutine(loadlevel(SceneManager.GetActiveScene().buildIndex + 1));
    }





    IEnumerator loadlevel(int loadlevel)
    {
        transition.SetTrigger("start");


        yield return new WaitForSeconds(transitiontime);


        SceneManager.LoadScene(loadlevel);




    }
}
