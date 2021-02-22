using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shootingAI : MonoBehaviour
{
    public EnemyData data;
    public GameObject player;
    public float timer = 0;
    
    public TextMeshPro uiText;
    public Color enemyUIColor;

    public bool isVisibleGizmo = true;
    [Range(5.0f, 15.0f)]
    public float MinUIRange = 10.0f;
    public Color MinUIRangeColor = Color.red;
    [Range(20.0f, 50.0f)]
    public float MaxUIRange = 40.0f;
    public Color MaxUIRangeColor = Color.green;

    private GameObject bullet;
    private Vector3 offset = new Vector3(0, 1, 0);

    private bool hasFire = false;

    // Start is called before the first frame update
    void Start()
    {
        uiText.text = data.Name + "\n" + data.Health;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist >= MinUIRange && dist <= MaxUIRange)
        {
            uiText.faceColor = enemyUIColor;
        }
        else
        {
            uiText.faceColor = new Color(0,0,0,0);
        }


        facetarget();
        if (data.Type != EnemyType.NoRange)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance <= data.Range)
            {
                timer += Time.deltaTime;

                if (timer >= data.ReloadTime)
                {
                    Quaternion rot = Quaternion.LookRotation(player.transform.position);
                    bullet = (GameObject)Instantiate(data.ProjectilePrefab, transform.position + offset, rot);

                    BulletOwner bulletHandler = bullet.GetComponent<BulletOwner>();

                    bulletHandler.owner = data.Name;
                    bulletHandler.normalDamage = data.NormalDamage;
                    bulletHandler.isBoss = data.isBoss;
                    bulletHandler.criticalDamage = data.CriticalDamage;

                    bullet.transform.LookAt(player.transform.position);
                    
                    hasFire = true;
                    timer = 0;
                    
                }
            }
        }

        if (hasFire)
        {
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * data.ProjectileSpeed * Time.deltaTime;
            hasFire = false;
        }
    }
    
    void facetarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmos()
    {
        if (isVisibleGizmo)
        {
            Gizmos.color = MinUIRangeColor;
            Gizmos.DrawWireSphere(transform.position, MinUIRange);

            Gizmos.color = MaxUIRangeColor;
            Gizmos.DrawWireSphere(transform.position, MaxUIRange);
        }
    }
}
