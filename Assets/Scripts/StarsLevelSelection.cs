using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsLevelSelection : MonoBehaviour
{

    public GameObject star1Tutorial, star2Tutorial, star3Tutorial;
    public GameObject star1Level1, star2Level1, star3Level1;
    public GameObject star1Level2, star2Level2, star3Level2;
    public GameObject star1Level3, star2Level3, star3Level3;
    public GameObject star1Level4, star2Level4, star3Level4;
    public GameObject star1Level5, star2Level5, star3Level5;




    int starsTutorial;
    int stars1stLevel;
    int stars2ndLevel;
    int stars3rdLevel;
    int stars4thLevel;
    int stars5thLevel;

    // Start is called before the first frame update
    void Start()
    {

        starsTutorial = PlayerPrefs.GetInt("StarsTutorial", 0);
        stars1stLevel = PlayerPrefs.GetInt("Stars1stLevel", 0);
        stars2ndLevel = PlayerPrefs.GetInt("Stars2ndLevel", 0);
        stars3rdLevel = PlayerPrefs.GetInt("Stars3rdLevel", 0);
        stars4thLevel = PlayerPrefs.GetInt("Stars4thLevel", 0);
        stars4thLevel = PlayerPrefs.GetInt("Stars5thLevel", 0);

        //TUTORIAL

        if (starsTutorial == 3)
        {
            star1Tutorial.SetActive(true);
            star2Tutorial.SetActive(true);
            star3Tutorial.SetActive(true);
        }

        if (starsTutorial == 2)
        {
            star1Tutorial.SetActive(true);
            star2Tutorial.SetActive(true);
        }

        if (starsTutorial == 1)
        {
            star1Tutorial.SetActive(true);
        }


        //LEVEL 1

        if(stars1stLevel == 3)
        {
            star1Level1.SetActive(true);
            star2Level1.SetActive(true);
            star3Level1.SetActive(true);
        }

        if (stars1stLevel == 2)
        {
            star1Level1.SetActive(true);
            star2Level1.SetActive(true);
        }

        if (stars1stLevel == 1)
        {
            star1Level1.SetActive(true);
        }


        //LEVEL 2


        if (stars2ndLevel == 3)
        {
            star1Level2.SetActive(true);
            star2Level2.SetActive(true);
            star3Level2.SetActive(true);
        }

        if (stars2ndLevel == 2)
        {
            star1Level2.SetActive(true);
            star2Level2.SetActive(true);
        }

        if (stars2ndLevel == 1)
        {
            star1Level2.SetActive(true);
        }

        //LEVEL 3


        if (stars3rdLevel == 3)
        {
            star1Level3.SetActive(true);
            star2Level3.SetActive(true);
            star3Level3.SetActive(true);
        }

        if (stars3rdLevel == 2)
        {
            star1Level3.SetActive(true);
            star2Level3.SetActive(true);
        }

        if (stars3rdLevel == 1)
        {
            star1Level3.SetActive(true);
        }


        //LEVEL 4


        if (stars4thLevel == 3)
        {
            star1Level4.SetActive(true);
            star2Level4.SetActive(true);
            star3Level4.SetActive(true);
        }

        if (stars4thLevel == 2)
        {
            star1Level4.SetActive(true);
            star2Level4.SetActive(true);
        }

        if (stars4thLevel == 1)
        {
            star1Level4.SetActive(true);
        }


        //LEVEL 5


        if (stars5thLevel == 3)
        {
            star1Level5.SetActive(true);
            star2Level5.SetActive(true);
            star3Level5.SetActive(true);
        }

        if (stars5thLevel == 2)
        {
            star1Level5.SetActive(true);
            star2Level5.SetActive(true);
        }

        if (stars5thLevel == 1)
        {
            star1Level5.SetActive(true);
        }
    }

}
