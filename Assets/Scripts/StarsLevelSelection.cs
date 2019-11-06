using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsLevelSelection : MonoBehaviour
{

    public GameObject star1Tutorial, star2Tutorial, star3Tutorial;
    public GameObject star1Level1, star2Level1, star3Level1;

    int starsTutorial;
    int stars1stLevel;
    // Start is called before the first frame update
    void Start()
    {

        starsTutorial = PlayerPrefs.GetInt("StarsTutorial", 0);
        stars1stLevel = PlayerPrefs.GetInt("Stars1stLevel", 0);

        //TUTORIAL

        if(starsTutorial == 3)
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
    }

}
