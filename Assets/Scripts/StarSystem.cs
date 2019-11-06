using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StarSystem : MonoBehaviour
{
    Scene currentScene;
    string sceneName;
    int stars;
    int starsTutorial;
    int stars1stLevel;
    int score;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public Text scoreText;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        starsTutorial = PlayerPrefs.GetInt("StarsTutorial", 0);
        stars1stLevel = PlayerPrefs.GetInt("Stars1stLevel", 0);
        score = PlayerPrefs.GetInt("score", 0);

    }

    private void Update()
    {
        stars = gameObject.GetComponent<Respawn>().stars;

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "winTrigger")
        {

            if (sceneName == "tutorial")
            {
                if(stars == 3)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);

                    score += 15;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");



                    if (starsTutorial < 3)
                    {
                        PlayerPrefs.SetInt("StarsTutorial", 3);

                    }

                }

                if (stars == 2)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);



                    score += 10;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");


                    if (starsTutorial < 2)
                    {
                        PlayerPrefs.SetInt("StarsTutorial", 2);

                    }

                }

                if (stars == 1)
                {
                    star1.SetActive(true);


                    score += 5;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");


                    if (starsTutorial < 1)
                    {
                        PlayerPrefs.SetInt("StarsTutorial", 1);

                    }
                }

              
            }


            if (sceneName == "1st Level")
            {
                if (stars == 3)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);

                    score += 15;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");


                    if (stars1stLevel < 3)
                    {
                        PlayerPrefs.SetInt("Stars1stLevel", 3);
                    }
                }

                if (stars == 2)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);

                    score += 10;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars1stLevel < 2)
                    {
                        PlayerPrefs.SetInt("Stars1stLevel", 2);

                    }

                }

                if (stars == 1)
                {
                    star1.SetActive(true);

                    score += 5;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars1stLevel < 1)
                    {
                        PlayerPrefs.SetInt("Stars1stLevel", 1);

                    }

                }


            }

            if (sceneName == "2nd Level")
            {
                if (stars == 3)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);

                }

                if (stars == 2)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);

                }

                if (stars == 1)
                {
                    star1.SetActive(true);

                }


            }
        }
    }
}
