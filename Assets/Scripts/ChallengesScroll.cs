using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengesScroll : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject exclamationPoint;
    void Start()
    {
        exclamationPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("claim1", 0) == 0 || PlayerPrefs.GetInt("claim2", 0) == 0 || PlayerPrefs.GetInt("claim3", 0) == 0)
        {
            exclamationPoint.SetActive(true);
        }

    }
}
