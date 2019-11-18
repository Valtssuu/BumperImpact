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
    int stars2ndLevel;
    int stars3rdLevel;
    int stars4thLevel;
    int stars5thLevel;
    int stars6thLevel;
    int stars7thLevel;

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
        stars2ndLevel = PlayerPrefs.GetInt("Stars2ndLevel", 0);
        stars3rdLevel = PlayerPrefs.GetInt("Stars3rdLevel", 0);
        stars4thLevel = PlayerPrefs.GetInt("Stars4thLevel", 0);
        stars5thLevel = PlayerPrefs.GetInt("Stars5thLevel", 0);
        stars6thLevel = PlayerPrefs.GetInt("Stars6thLevel", 0);
        stars7thLevel = PlayerPrefs.GetInt("Stars7thLevel", 0);


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

            //TUTORIAl

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

            //LEVEL 1

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


            //LEVEL 2
            if (sceneName == "2nd Level")
            {
                if (stars == 3)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);

                    score += 15;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars2ndLevel < 3)
                    {
                        PlayerPrefs.SetInt("Stars2ndLevel", 3);
                    }


                }

                if (stars == 2)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);

                    score += 10;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars2ndLevel < 2)
                    {
                        PlayerPrefs.SetInt("Stars2ndLevel", 2);
                    }

                }

                if (stars == 1)
                {
                    star1.SetActive(true);

                    score += 5;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars2ndLevel < 1)
                    {
                        PlayerPrefs.SetInt("Stars2ndLevel", 1);
                    }

                }




            }


            //LEVEL 3
            if (sceneName == "3rd Level")
            {
                if (stars == 3)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);

                    score += 15;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars3rdLevel < 3)
                    {
                        PlayerPrefs.SetInt("Stars3rdLevel", 3);
                    }


                }

                if (stars == 2)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);

                    score += 10;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars3rdLevel < 2)
                    {
                        PlayerPrefs.SetInt("Stars3rdLevel", 2);
                    }

                }

                if (stars == 1)
                {
                    star1.SetActive(true);

                    score += 5;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars3rdLevel < 1)
                    {
                        PlayerPrefs.SetInt("Stars3rdLevel", 1);
                    }

                }




            }

            //LEVEL 4
            if (sceneName == "4th Level")
            {
                if (stars == 3)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);

                    score += 15;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars4thLevel < 3)
                    {
                        PlayerPrefs.SetInt("Stars4thLevel", 3);
                    }


                }

                if (stars == 2)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);

                    score += 10;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars4thLevel < 2)
                    {
                        PlayerPrefs.SetInt("Stars4thLevel", 2);
                    }

                }

                if (stars == 1)
                {
                    star1.SetActive(true);

                    score += 5;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars4thLevel < 1)
                    {
                        PlayerPrefs.SetInt("Stars4thLevel", 1);
                    }

                }




            }
            //LEVEL 5
            if (sceneName == "5th Level")
            {
                if (stars == 3)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);

                    score += 15;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars5thLevel < 3)
                    {
                        PlayerPrefs.SetInt("Stars5thLevel", 3);
                    }


                }

                if (stars == 2)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);

                    score += 10;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars5thLevel < 2)
                    {
                        PlayerPrefs.SetInt("Stars5thLevel", 2);
                    }

                }

                if (stars == 1)
                {
                    star1.SetActive(true);

                    score += 5;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars5thLevel < 1)
                    {
                        PlayerPrefs.SetInt("Stars5thLevel", 1);
                    }

                }




            }


            //LEVEL 6
            if (sceneName == "6th Level")
            {
                if (stars == 3)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);

                    score += 15;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars6thLevel < 3)
                    {
                        PlayerPrefs.SetInt("Stars6thLevel", 3);
                    }


                }

                if (stars == 2)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);

                    score += 10;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars6thLevel < 2)
                    {
                        PlayerPrefs.SetInt("Stars6thLevel", 2);
                    }

                }

                if (stars == 1)
                {
                    star1.SetActive(true);

                    score += 5;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars6thLevel < 1)
                    {
                        PlayerPrefs.SetInt("Stars6thLevel", 1);
                    }

                }




            }
            //LEVEL 7
            if (sceneName == "7th Level")
            {
                if (stars == 3)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);

                    score += 15;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars7thLevel < 3)
                    {
                        PlayerPrefs.SetInt("Stars7thLevel", 3);
                    }


                }

                if (stars == 2)
                {
                    star1.SetActive(true);
                    star2.SetActive(true);

                    score += 10;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars7thLevel < 2)
                    {
                        PlayerPrefs.SetInt("Stars7thLevel", 2);
                    }

                }

                if (stars == 1)
                {
                    star1.SetActive(true);

                    score += 5;
                    PlayerPrefs.SetInt("score", score);
                    scoreText.text = score.ToString("");

                    if (stars7thLevel < 1)
                    {
                        PlayerPrefs.SetInt("Stars7thLevel", 1);
                    }

                }




            }
        }
    }
}
