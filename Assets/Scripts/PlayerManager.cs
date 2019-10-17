using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //?? to find the player
    #region Singleton

    public static PlayerManager instance;

    void Awake ()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
