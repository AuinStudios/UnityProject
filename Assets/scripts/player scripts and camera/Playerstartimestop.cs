using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstartimestop : MonoBehaviour
{
    public TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) //Stop Time when Q is pressed
        {
            timeManager.StopTime();
            
        }
        if (Input.GetKeyDown(KeyCode.T) && timeManager.TimeisStopped)  //Continue Time when E is pressed
        {
            timeManager.ContinueTime();
            

        }
    }
}
