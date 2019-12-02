using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyChallenges : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject claim1, claim2, claim3, claim1Disabled, claim2Disabled, claim3Disabled;
    int score;
    public Text scoreText;
    public Text challenge1Text;
    void Start()
    {
        if(PlayerPrefs.GetInt("endlessKills", 0) < 40)
        {
            challenge1Text.text = "Destroy " + (40 - PlayerPrefs.GetInt("endlessKills", 0)) + " enemies \nin endless mode";

        }
        else
        {
            challenge1Text.text = "Destroy 0" + " enemies \nin endless mode";

        }
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("score", 0);

        if(PlayerPrefs.GetInt("claim1", 0 ) == 1)
        {
            claim1Disabled.SetActive(false);
            claim1.SetActive(false);
        }
        if (PlayerPrefs.GetInt("claim2", 0) == 1)
        {
            claim2Disabled.SetActive(false);
            claim2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("claim3", 0) == 1)
        {
            claim3Disabled.SetActive(false);
            claim3.SetActive(false);
        }

        if(PlayerPrefs.GetInt("endlessKills", 0) >= 40)
        {
            claim1Disabled.SetActive(false);
        }

        if (PlayerPrefs.GetInt("bossDefeated", 0) == 1)
        {
            claim2Disabled.SetActive(false);
        }
        if (PlayerPrefs.GetInt("timesBuyDash", 0) > 0)
        {

            claim3Disabled.SetActive(false);
        }


    }

    public void Claim1Clicked()
    {
        score += 50;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString("");
        claim1.SetActive(false);

        PlayerPrefs.SetInt("claim1", 1);
    }
    public void Claim2Clicked()
    {
        
        score += 50;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString("");
        claim2.SetActive(false);
        PlayerPrefs.SetInt("claim2", 1);
        
        


    }
    public void Claim3Clicked()
    {
        
        score += 50;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString("");
        claim3.SetActive(false);
        PlayerPrefs.SetInt("claim3", 1);
        
        
    }
}
