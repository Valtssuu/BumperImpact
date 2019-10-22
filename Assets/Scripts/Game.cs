using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int score;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame () 
    {
        SceneManager.LoadScene ("Game");
    }
 
    public void QuitGame ()
    {
        Debug.Log ("QUIT!");
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
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
        SceneManager.LoadScene("Level2");
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void Buy()
    {
        //ei toimi ku ei updateta sitä heti
        if(score > 2)
        {
            score = score - 2;
            PlayerPrefs.SetInt("score", score);
            Debug.Log("terve");
            scoreText.text = score.ToString();
        }
    }
}
