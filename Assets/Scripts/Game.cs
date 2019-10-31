using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int score;
    public Button buyButton, buyDashButton;
    public Text scoreText;
    public int dashDmg;
    public GameObject TApanel, GoldPanel, NormalPanel, disabledButton, activeButton, activeDashBuy, disabledDashBuy;
    public int accept;
    // Start is called before the first frame update
    void Start()
    {
        accept = PlayerPrefs.GetInt("AcceptTA", 0);
        score = PlayerPrefs.GetInt("score", 0);
        dashDmg = PlayerPrefs.GetInt("dashDmg", 0);

        if(accept == 0)
        {
            TApanel.SetActive(true);
        }

        if (PlayerPrefs.GetInt("skin") == 1)
        {
            buyButton.interactable = false;
            activeButton.SetActive(false);
            disabledButton.SetActive(true);
            
        }

        if (PlayerPrefs.GetInt("hasDash") == 1)
        {

            activeDashBuy.SetActive(false);
            disabledDashBuy.SetActive(true);
            buyDashButton.interactable = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame () 
    {
        SceneManager.LoadScene ("Tutorial");
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
    public void Level1()
    {
        SceneManager.LoadScene("1st Level");
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
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
        if(score >= 500)
        {
            score = score - 500;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();
            dashDmg += 70;
            PlayerPrefs.SetInt("dashDmg", dashDmg);
            PlayerPrefs.SetInt("hasDash", 1);
            activeDashBuy.SetActive(false);
            disabledDashBuy.SetActive(true);
            buyDashButton.interactable = false;

        }

    }

    public void Reset()
    {
        PlayerPrefs.SetInt("skin", 0);
        PlayerPrefs.SetInt("dashDmg", 0);
        PlayerPrefs.SetInt("hasDash", 0);

    }

    public void AdWasClicked()
    {
        score = score + 10;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString();
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
