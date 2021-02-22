using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermanager : MonoBehaviour
{

    #region Singleton
    public static Playermanager instance;


    private void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject Player;
}
