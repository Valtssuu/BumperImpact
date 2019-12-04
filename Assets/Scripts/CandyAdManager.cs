using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class CandyAdManager : MonoBehaviour
{
    // Start is called before the first frame update

    int score;
    int sessionScore;
    public Text sessionScoreText;
    GameObject player;
    Text scoreText;
    public GameObject doubleButton;
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        player = GameObject.FindWithTag("Player");
        scoreText = player.GetComponent<PlayerController>().scoreText;
    }

    // Update is called once per frame
    void Update()
    {
        sessionScore = player.GetComponent<Respawn>().sessionScore;

        sessionScoreText.text = sessionScore.ToString();
    }

    public void ShowAd()
    {
        doubleButton.SetActive(false);
        StartCoroutine(giveTickets());

        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");

        }
    }
    private IEnumerator giveTickets()
    {
        yield return new WaitForSeconds(10f);
        player.GetComponent<Respawn>().sessionScore = sessionScore * 2;
        sessionScoreText.text = sessionScore.ToString();
        player.GetComponent<PlayerController>().score = player.GetComponent<PlayerController>().score + sessionScore;
        
        
    }
}
