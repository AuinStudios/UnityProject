using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class respawnscript : MonoBehaviour
{
    [Header("Respawn player")]
    public GameObject player;
    [Range(-150.0f, -10.0f)]
    public float RespawnLowLimit = -100.0f;
    public GameObject RespawnPoint;

    [Header("scene restart")]
    public KeyCode RestartSceneButton;
    public string sceneToRestart;

    void Update()
    {
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

        if (Input.GetKeyDown(RestartSceneButton))
        {
            SceneManager.LoadScene("menu");
        }
    }
}
