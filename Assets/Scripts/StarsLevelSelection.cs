﻿using System.Collections;
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
    public GameObject star1Level6, star2Level6, star3Level6;
    public GameObject star1Level7, star2Level7, star3Level7;
    public GameObject star1Level8, star2Level8, star3Level8;
    public GameObject star1Level9, star2Level9, star3Level9;
    public GameObject star1Level10, star2Level10, star3Level10;
    public GameObject star1Level11, star2Level11, star3Level11;
    public GameObject star1Level12, star2Level12, star3Level12;
    public GameObject star1Level13, star2Level13, star3Level13;
    public GameObject star1Level14, star2Level14, star3Level14;
    public GameObject star1Level15, star2Level15, star3Level15;
    public GameObject star1Level16, star2Level16, star3Level16;


    public GameObject star1LevelBoss, star2LevelBoss, star3LevelBoss;





    int starsTutorial;
    int stars1stLevel;
    int stars2ndLevel;
    int stars3rdLevel;
    int stars4thLevel;
    int stars5thLevel;
    int stars6thLevel;
    int stars7thLevel;
    int stars8thLevel;
    int stars9thLevel;
    int stars10thLevel;
    int stars11thLevel;
    int stars12thLevel;
    int stars13thLevel;
    int stars14thLevel;
    int stars15thLevel;
    int stars16thLevel;

    int starsBossLevel;


    // Start is called before the first frame update
    void Start()
    {

        starsTutorial = PlayerPrefs.GetInt("StarsTutorial", 0);
        stars1stLevel = PlayerPrefs.GetInt("Stars1stLevel", 0);
        stars2ndLevel = PlayerPrefs.GetInt("Stars2ndLevel", 0);
        stars3rdLevel = PlayerPrefs.GetInt("Stars3rdLevel", 0);
        stars4thLevel = PlayerPrefs.GetInt("Stars4thLevel", 0);
        stars5thLevel = PlayerPrefs.GetInt("Stars5thLevel", 0);
        stars6thLevel = PlayerPrefs.GetInt("Stars6thLevel", 0);
        stars7thLevel = PlayerPrefs.GetInt("Stars7thLevel", 0);
        stars8thLevel = PlayerPrefs.GetInt("Stars8thLevel", 0);
        stars9thLevel = PlayerPrefs.GetInt("Stars9thLevel", 0);
        stars10thLevel = PlayerPrefs.GetInt("Stars10thLevel", 0);
        stars11thLevel = PlayerPrefs.GetInt("Stars11thLevel", 0);
        stars12thLevel = PlayerPrefs.GetInt("Stars12thLevel", 0);
        stars13thLevel = PlayerPrefs.GetInt("Stars13thLevel", 0);
        stars14thLevel = PlayerPrefs.GetInt("Stars14thLevel", 0);
        stars15thLevel = PlayerPrefs.GetInt("Stars15thLevel", 0);
        stars16thLevel = PlayerPrefs.GetInt("Stars16thLevel", 0);


        starsBossLevel = PlayerPrefs.GetInt("StarsBossLevel", 0);



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

        //LEVEL 6


        if (stars6thLevel == 3)
        {
            star1Level6.SetActive(true);
            star2Level6.SetActive(true);
            star3Level6.SetActive(true);
        }

        if (stars6thLevel == 2)
        {
            star1Level6.SetActive(true);
            star2Level6.SetActive(true);
        }

        if (stars6thLevel == 1)
        {
            star1Level6.SetActive(true);
        }
        //LEVEL 7


        if (stars7thLevel == 3)
        {
            star1Level7.SetActive(true);
            star2Level7.SetActive(true);
            star3Level7.SetActive(true);
        }

        if (stars7thLevel == 2)
        {
            star1Level7.SetActive(true);
            star2Level7.SetActive(true);
        }

        if (stars7thLevel == 1)
        {
            star1Level7.SetActive(true);
        }
        //LEVEL 8


        if (stars8thLevel == 3)
        {
            star1Level8.SetActive(true);
            star2Level8.SetActive(true);
            star3Level8.SetActive(true);
        }

        if (stars8thLevel == 2)
        {
            star1Level8.SetActive(true);
            star2Level8.SetActive(true);
        }

        if (stars8thLevel == 1)
        {
            star1Level8.SetActive(true);
        }
        //LEVEL 9


        if (stars9thLevel == 3)
        {
            star1Level9.SetActive(true);
            star2Level9.SetActive(true);
            star3Level9.SetActive(true);
        }

        if (stars9thLevel == 2)
        {
            star1Level9.SetActive(true);
            star2Level9.SetActive(true);
        }

        if (stars9thLevel == 1)
        {
            star1Level9.SetActive(true);
        }
        //LEVEL 10


        if (stars10thLevel == 3)
        {
            star1Level10.SetActive(true);
            star2Level10.SetActive(true);
            star3Level10.SetActive(true);
        }

        if (stars10thLevel == 2)
        {
            star1Level10.SetActive(true);
            star2Level10.SetActive(true);
        }

        if (stars10thLevel == 1)
        {
            star1Level10.SetActive(true);
        }
        //LEVEL 11


        if (stars11thLevel == 3)
        {
            star1Level11.SetActive(true);
            star2Level11.SetActive(true);
            star3Level11.SetActive(true);
        }

        if (stars11thLevel == 2)
        {
            star1Level11.SetActive(true);
            star2Level11.SetActive(true);
        }

        if (stars11thLevel == 1)
        {
            star1Level11.SetActive(true);
        }
        //LEVEL 12


        if (stars12thLevel == 3)
        {
            star1Level12.SetActive(true);
            star2Level12.SetActive(true);
            star3Level12.SetActive(true);
        }

        if (stars12thLevel == 2)
        {
            star1Level12.SetActive(true);
            star2Level12.SetActive(true);
        }

        if (stars12thLevel == 1)
        {
            star1Level12.SetActive(true);
        }
        //LEVEL 13


        if (stars13thLevel == 3)
        {
            star1Level13.SetActive(true);
            star2Level13.SetActive(true);
            star3Level13.SetActive(true);
        }

        if (stars13thLevel == 2)
        {
            star1Level13.SetActive(true);
            star2Level13.SetActive(true);
        }

        if (stars13thLevel == 1)
        {
            star1Level13.SetActive(true);
        }
        //LEVEL 14


        if (stars14thLevel == 3)
        {
            star1Level14.SetActive(true);
            star2Level14.SetActive(true);
            star3Level14.SetActive(true);
        }

        if (stars14thLevel == 2)
        {
            star1Level14.SetActive(true);
            star2Level14.SetActive(true);
        }

        if (stars14thLevel == 1)
        {
            star1Level14.SetActive(true);
        }
        //LEVEL 15


        if (stars15thLevel == 3)
        {
            star1Level15.SetActive(true);
            star2Level15.SetActive(true);
            star3Level15.SetActive(true);
        }

        if (stars15thLevel == 2)
        {
            star1Level15.SetActive(true);
            star2Level15.SetActive(true);
        }

        if (stars15thLevel == 1)
        {
            star1Level15.SetActive(true);
        }//LEVEL 16


        if (stars16thLevel == 3)
        {
            star1Level16.SetActive(true);
            star2Level16.SetActive(true);
            star3Level16.SetActive(true);
        }

        if (stars16thLevel == 2)
        {
            star1Level16.SetActive(true);
            star2Level16.SetActive(true);
        }

        if (stars16thLevel == 1)
        {
            star1Level16.SetActive(true);
        }
        //Boss Level


        if (starsBossLevel == 3)
        {
            star1LevelBoss.SetActive(true);
            star2LevelBoss.SetActive(true);
            star3LevelBoss.SetActive(true);
        }

        if (starsBossLevel == 2)
        {
            star1LevelBoss.SetActive(true);
            star2LevelBoss.SetActive(true);
        }

        if (starsBossLevel == 1)
        {
            star1LevelBoss.SetActive(true);
        }


    }

}
