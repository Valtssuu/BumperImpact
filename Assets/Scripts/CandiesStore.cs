using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandiesStore : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;

    public Text scoreText;
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString("");
    }

    // Update is called once per frame
    void Update()
    {
        // you have been hacked
        Debug.LogError("you have been hacked");
    }
}
