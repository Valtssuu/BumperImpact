using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class DailyReward : MonoBehaviour
{

    int sysDay = System.DateTime.Now.Day;
    public GameObject DailyRewardPanel;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        if (PlayerPrefs.GetInt("sysDayReward", 0) != sysDay)
        {
            score += 20;
            DailyRewardPanel.SetActive(true);
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("sysDayReward", sysDay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueReward()
    {
        DailyRewardPanel.SetActive(false);
    }
}
