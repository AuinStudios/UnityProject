using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class respawnscript : MonoBehaviour
{
    [Header("Respawn player")]
    public GameObject player;
    [Range(-150.0f, -10.0f)]
    public float RespawnLowLimit = -100.0f;
    public GameObject RespawnPoint, menu, background, continuee;
    public Animator pause;
    [Header("scene restart")]
    public KeyCode RestartSceneButton;
    public string sceneToRestart;
    public PlayerHealthHandler whendeath;
    public Newplayer whendeadplayer;

    public void Helpme()
    {
        if (whendeath.Health <= 0)
        {
            continuee.SetActive(false);
            pause.GetComponent<Animator>().enabled = false;
            background.GetComponent<CanvasGroup>().alpha = 0.5f;
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            whendeadplayer.maxspeed = 0;
           
        }
    }

    

    void Update()
    {
        Helpme();

        if (player.transform.position.y <= RespawnLowLimit)
        {
            try
            {
                player.transform.position = new Vector3(RespawnPoint.transform.position.x, RespawnPoint.transform.position.y + player.transform.localScale.y + 0.1f, RespawnPoint.transform.position.z);
            }
            catch (System.Exception)
            {

                throw;
            }


           
        }

        if (Input.GetKeyDown(RestartSceneButton) && !(whendeath.Health <= 0))
        {
            pause.GetComponent<Animator>().enabled = false;
            background.GetComponent<CanvasGroup>().alpha = 0.5f;
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            continuee.SetActive(true);
        }

    }
}
    

