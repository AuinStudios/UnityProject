using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTown : MonoBehaviour
{
    public GameObject cube;
    public GameObject spawnPosition;
    public int AmountToGenerate;
    public int RangeToGenerate;
    public float timerOfDeath = 5;
    float timer;

    // Start is called before the first frame update
    void Update()
    {

       
         timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.I))
        {
 if (timer >= timerOfDeath)
        {
            for (int i = 0; i < AmountToGenerate; i++)
            {
                //Vector3 offset = new Vector3(spawnPosition.transform.position.x + RangeToGenerate, spawnPosition.transform.position.y, spawnPosition.transform.position.z - RangeToGenerate);

                Vector3 pos = new Vector3(Random.Range(spawnPosition.transform.position.x - RangeToGenerate, spawnPosition.transform.position.x + RangeToGenerate), 
                                          -2.9f,
                                          Random.Range(spawnPosition.transform.position.z - RangeToGenerate, spawnPosition.transform.position.z + RangeToGenerate));
                Quaternion rot = new Quaternion(0, 1, 0, 0);
                Instantiate(cube, pos, rot);
            }

            timer = 0;
        }
    }
        }
       
        
       

}
