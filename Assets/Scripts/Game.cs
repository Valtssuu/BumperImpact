using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Game : MonoBehaviour
{
    public int score;
    public Button buyButton, buyDashButton, buySmallDashButton;
    public Text scoreText;
    public int dashDmg;
    public GameObject TApanel, GoldPanel, NormalPanel, disabledButton, activeButton, activeDashBuy, disabledDashBuy, adButton;
    public int accept;
    public bool tutorial, level1, level2, level3, level4, level5, level6, level7;
    public GameObject tutorialButton, level1Button, level2Button, level3Button , level4Button, level5Button, level6Button, level7Button;
    public GameObject car;

    public int timesBuyDash;
    public int boughtAll;
    private bool smallDashDone = false;
    // Start is called before the first frame update
    void Start()
    {
        accept = PlayerPrefs.GetInt("AcceptTA", 0);
        score = PlayerPrefs.GetInt("score", 0);
        dashDmg = PlayerPrefs.GetInt("dashDmg", 0);
        timesBuyDash = PlayerPrefs.GetInt("timesBuyDash", 0);
        boughtAll = PlayerPrefs.GetInt("boughtAll", 0);


        InvokeRepeating("ShowAdAfter1min", 0, 20);


        if (accept == 0)
        {
            TApanel.SetActive(true);
        }

        if (PlayerPrefs.GetInt("skin") == 1)
        {
            buyButton.interactable = false;
            activeButton.SetActive(false);
            disabledButton.SetActive(true);
            
        }

        if (PlayerPrefs.GetInt("hasDash") == 1 || PlayerPrefs.GetInt("boughtAll") == 0)
        {

            activeDashBuy.SetActive(false);
            disabledDashBuy.SetActive(true);
            buyDashButton.interactable = false;
        }

        if (PlayerPrefs.GetInt("boughtAll") == 1)
        {
            buySmallDashButton.interactable = false;
            activeDashBuy.SetActive(true);
            disabledDashBuy.SetActive(false);
            buyDashButton.interactable = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timesBuyDash == 2 && smallDashDone == false)
        {
            buySmallDashButton.interactable = false;
            activeDashBuy.SetActive(true);
            disabledDashBuy.SetActive(false);
            buyDashButton.interactable = true;
            PlayerPrefs.SetInt("boughtAll", 1);
            smallDashDone = true;
        }
    }
   

    public void QuitGame ()
    {
        Debug.Log ("QUIT!");
        Application.Quit();
    }
    public void TestLevel()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Store()
    {
        SceneManager.LoadScene("Store");
    }

    public void Tutorial()
    {
        //SceneManager.LoadScene ("Tutorial");
        car.transform.position = tutorialButton.transform.position;
        tutorial = true;
        level1 = false;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
        level6 = false;
        level7 = false;



    }
    public void Level1()
    {
        //SceneManager.LoadScene("1st Level");
        car.transform.position = level1Button.transform.position;
        tutorial = false;
        level1 = true;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
        level6 = false;
        level7 = false;

    }
    public void Level2()
    {
        //SceneManager.LoadScene("2nd Level");
        car.transform.position = level2Button.transform.position;
        
        tutorial = false;
        level1 = false;
        level2 = true;
        level3 = false;
        level4 = false;
        level5 = false;
        level6 = false;
        level7 = false;

    }

    public void Level3()
    {
        //SceneManager.LoadScene("3rd Level");
        car.transform.position = level3Button.transform.position;
        tutorial = false;
        level1 = false;
        level2 = false;
        level3 = true;
        level4 = false;
        level5 = false;
        level6 = false;
        level7 = false;

    }

    public void Level4()
    {
        //SceneManager.LoadScene("4th Level");
        car.transform.position = level4Button.transform.position;
        tutorial = false;
        level1 = false;
        level2 = false;
        level3 = false;
        level4 = true;
        level5 = false;
        level6 = false;
        level7 = false;

    }
    public void Level5()
    {
        //SceneManager.LoadScene("5th Level");
        car.transform.position = level5Button.transform.position;
        tutorial = false;
        level1 = false;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = true;
        level6 = false;
        level7 = false;

    }
    public void Level6()
    {
        //SceneManager.LoadScene("6th Level");
        car.transform.position = level6Button.transform.position;
        tutorial = false;
        level1 = false;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
        level6 = true;
        level7 = false;

    }

    public void Level7()
    {
        //SceneManager.LoadScene("6th Level");
        car.transform.position = level7Button.transform.position;
        tutorial = false;
        level1 = false;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
        level6 = false;
        level7 = true;
    }

    public void PlayGame()
    {
        if(tutorial == true)
        {
            SceneManager.LoadScene("Tutorial");
        }

        if(level1 == true)
        {
            SceneManager.LoadScene("1st Level");
        }
        if (level2 == true)
        {
            SceneManager.LoadScene("2nd Level");
        }
        if (level3 == true)
        {
            SceneManager.LoadScene("3rd Level");
        }
        if (level4 == true)
        {
            SceneManager.LoadScene("4th Level");
        }
        if (level5 == true)
        {
            SceneManager.LoadScene("5th Level");
        }
        if (level6 == true)
        {
            SceneManager.LoadScene("6th Level");
        }

        if (level7 == true)
        {
            SceneManager.LoadScene("7th Level");
        }

    }

    public void LevelSelection()
    {
        SceneManager.LoadScene("WorldMap");
    }
    public void Endless()
    {
        SceneManager.LoadScene("Endless level");
    }

    public void Buy()
    {
        if(score >= 200)
        {
            score = score - 200;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("skin", 1);

            buyButton.interactable = false;
            activeButton.SetActive(false);
            disabledButton.SetActive(true);
        }

        
    }

    public void UpgradeDash()
    {
        if(score >= 5)
        {
            score = score - 5;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();
            dashDmg += 50;
            PlayerPrefs.SetInt("dashDmg", dashDmg);
            PlayerPrefs.SetInt("hasDash", 1);
            activeDashBuy.SetActive(false);
            disabledDashBuy.SetActive(true);
            buyDashButton.interactable = false;

        }

    }
     public void UpgradeSmallDash()
    {
        if (score >= 2)
        {
            
            if (timesBuyDash <= 1)
            {
                timesBuyDash++;
                PlayerPrefs.SetInt("timesBuyDash", timesBuyDash);
                score = score - 2;
                PlayerPrefs.SetInt("score", score);
                scoreText.text = score.ToString();
                dashDmg += 20;
                PlayerPrefs.SetInt("dashDmg", dashDmg);
            }

            
            
            
        }
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("skin", 0);
        PlayerPrefs.SetInt("dashDmg", 0);
        PlayerPrefs.SetInt("hasDash", 0);
        PlayerPrefs.SetInt("timesBuyDash", 0);
        PlayerPrefs.SetInt("boughtAll", 0);
        activeDashBuy.SetActive(false);
        disabledDashBuy.SetActive(true);
        buyDashButton.interactable = false;
        buySmallDashButton.interactable = true;
    }

    public void AdWasClicked()
    {
        score = score + 20;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString();
        adButton.SetActive(false);
        
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");
        }
        
    }
    
    void ShowAdAfter1min()
    {
        adButton.SetActive(true);
    }

    public void OpenTerms()
    {
        Application.OpenURL("http://www.oulugamelab.net/t-a-c");
    }
    public void OpenPrivacy()
    {
        Application.OpenURL("http://www.oulugamelab.net/policy");
    }
    public void Accept()
    {
        TApanel.SetActive(false);
        PlayerPrefs.SetInt("AcceptTA", 1);
    }

    public void OpenGoldTickets()
    {
        GoldPanel.SetActive(true);
        NormalPanel.SetActive(false);
    }

    public void OpenNormalTickets()
    {
        GoldPanel.SetActive(false);
        NormalPanel.SetActive(true);
    }
}
