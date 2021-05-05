using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    [Range(10, 500)]
    public float Health = 100;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI textcolorui;
    float startingHealth;
    string enemyName;





    private void OnTriggerEnter(Collider coll)
    {


        if (coll.gameObject.CompareTag("explosivebarrel"))
        {
            BulletOwner bulletOwner = coll.gameObject.GetComponent<BulletOwner>();

            if (bulletOwner.isBoss)
            {
                Health -= bulletOwner.normalDamage + bulletOwner.criticalDamage;
            }
            else
            {
                Health -= bulletOwner.normalDamage;
            }
        }
            if (coll.gameObject.CompareTag( "explosiondamage"))
        {
            BulletOwner bulletOwner = coll.gameObject.GetComponent<BulletOwner>();

            if (bulletOwner.isBoss)
            {
                Health -= bulletOwner.normalDamage + bulletOwner.criticalDamage;
            }
            else
            {
                Health -= bulletOwner.normalDamage;
            }


        }
        if (coll.gameObject.CompareTag("lava"))
        {
            BulletOwner bulletOwner = coll.gameObject.GetComponent<BulletOwner>();

            if (bulletOwner.isBoss)
            {
                Health -= bulletOwner.normalDamage + bulletOwner.criticalDamage;
            }
            else
            {
                Health -= bulletOwner.normalDamage;
            }

            enemyName = bulletOwner.owner;
        }
    }
    private void Start()
    {
        startingHealth = Health;
    }

    private void Update()
    {
        HealthText.text = Mathf.Clamp((float)Health, 0, float.MaxValue).ToString();

       
        if (Health <= (startingHealth / 4))  // 25%
        {
            HealthText.faceColor = Color.red;
            textcolorui.faceColor = Color.red;
        }
        else if (Health <= (startingHealth / 3)) // 33.33%
        {
            HealthText.faceColor = Color.magenta;
            textcolorui.faceColor = Color.magenta;
        }
        else if (Health <= (startingHealth / 2)) // 50%
        {
            HealthText.faceColor = Color.yellow;
            textcolorui.faceColor = Color.yellow;
        }

        if (Health <= 0)   // 0%
        {
            Debug.LogWarning(enemyName + " fucking killed you...");

            SceneManager.LoadScene("menu");
        }
    }

     public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("bullet"))
        {
            BulletOwner bulletOwner = col.gameObject.GetComponent<BulletOwner>();

            if (bulletOwner.isBoss)
            {
                Health -= bulletOwner.normalDamage + bulletOwner.criticalDamage;
            }
            else
            {
                Health -= bulletOwner.normalDamage;
            }

            enemyName = bulletOwner.owner;
        }


       


    

}
}
