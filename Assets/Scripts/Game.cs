﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Game : MonoBehaviour
{
    public GameObject scroll, skinContainer, faceContainer;
    public GameObject prettyBuyButton, cuteBuyButton, sadhappyBuyButton, prettyApplyButton, cuteAppyButton, sadhappyApplyButton, camoBuyButton, leopardBuyButton, hippieBuyButton, camoApplyButton, leopardApplyButton, hippieApplyButton, skinBasicDisabled, skinCamoDisabled, skinHippieDisabled, skinLeopardDisabled, sadhappyDisabled, cuteDisabled, prettyDisabled, basicEmojiDisabled;
    public int score;
    public Button buyButton, buyDashButton, buyRocketButton;
    public Text scoreText, dashText, rocketText;
    public int dashDmg;
    public GameObject TApanel, GoldPanel, ChallengePanel, NormalPanel, disabledButton, activeButton, activeDashBuy, disabledDashBuy, adButton, activeRocketBuy, disabledRocketBuy, CosmeticBar;
    public string sceneName;

    public int accept;
    public bool tutorial, level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11, level12, level13, level14, level15, level16, levelBoss;
    public GameObject tutorialButton, level1Button, level2Button, level3Button , level4Button, level5Button, level6Button, level7Button, level8Button, level9Button, level10Button, level11Button, level12Button, level13Button, level14Button, level15Button, level16Button, levelBossButton;

    public GameObject car;
    public bool isLevel1Open, isLevel2Open, isLevel3Open, isLevel4Open, isLevel5Open, isLevel6Open, isLevel7Open, isLevel8Open, isLevel9Open, isLevel10Open, isLevel11Open, isLevel12Open, isLevel13Open, isLevel14Open, isLevel15Open, isLevel16Open, isLevelBossOpen;
    public int timesBuyDash;
    public GameObject lock1, lock2, lock3, lock4, lock5, lock6, lock7, lock8, lock9, lock10, lock11, lock12, lock13, lock14, lock15, lock16, lockBoss;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        
        dashDmg = PlayerPrefs.GetInt("dashDmg", 0);
        timesBuyDash = PlayerPrefs.GetInt("timesBuyDash", 0);
        
        InvokeRepeating("ShowAdAfter1min", 0, 20);
        lock1.SetActive(true);
        lock2.SetActive(true);
        lock3.SetActive(true);
        lock4.SetActive(true);
        lock5.SetActive(true);
        lock6.SetActive(true);
        lock7.SetActive(true);
        lock8.SetActive(true);
        lock9.SetActive(true);
        lock10.SetActive(true);
        lock11.SetActive(true);
        lock12.SetActive(true);
        lock13.SetActive(true);
        lock14.SetActive(true);
        lock15.SetActive(true);
        lock16.SetActive(true);

        lockBoss.SetActive(true);

        tutorial = true;


        levelBoss = false;


        if (PlayerPrefs.GetInt("Level1Open", 0) == 1)
        {
            isLevel1Open = true;
            lock1.SetActive(false);

            if (isLevel2Open == false || isLevel3Open == false || isLevel4Open == false || isLevel5Open == false || isLevel6Open == false || isLevel7Open == false || isLevel8Open == false || isLevel9Open == false || isLevel10Open == false || isLevel11Open == false || isLevel12Open == false || isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level1Button.transform.position;
                tutorial = false;
                level1 = true;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;
            }
        }
        

        
        if (PlayerPrefs.GetInt("Level2Open", 0) == 1)
        {
            isLevel2Open = true;
            lock2.SetActive(false);

            if (isLevel3Open == false || isLevel4Open == false || isLevel5Open == false || isLevel6Open == false || isLevel7Open == false || isLevel8Open == false || isLevel9Open == false || isLevel10Open == false || isLevel11Open == false || isLevel12Open == false || isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level2Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = true; 
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;

            }
        }
       
        if (PlayerPrefs.GetInt("Level3Open", 0) == 1)
        {
            isLevel3Open = true;
            lock3.SetActive(false);

            if ( isLevel4Open == false || isLevel5Open == false || isLevel6Open == false || isLevel7Open == false || isLevel8Open == false || isLevel9Open == false || isLevel10Open == false || isLevel11Open == false || isLevel12Open == false || isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level3Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = true;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;

            }
        }
        


        if (PlayerPrefs.GetInt("Level4Open", 0) == 1)
        {
            isLevel4Open = true;
            lock4.SetActive(false);

            if ( isLevel5Open == false || isLevel6Open == false || isLevel7Open == false || isLevel8Open == false || isLevel9Open == false || isLevel10Open == false || isLevel11Open == false || isLevel12Open == false || isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level4Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = true;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;

            }
        }
        
        if (PlayerPrefs.GetInt("Level5Open", 0) == 1)
        {
            isLevel5Open = true;
            lock5.SetActive(false);

            if (isLevel6Open == false || isLevel7Open == false || isLevel8Open == false || isLevel9Open == false || isLevel10Open == false || isLevel11Open == false || isLevel12Open == false || isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level5Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = true;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;


            }

            scroll.transform.position = scroll.transform.position + new Vector3(-1745, 0, 0);
        }
        


        if (PlayerPrefs.GetInt("Level6Open", 0) == 1)
        {
            isLevel6Open = true;
            lock6.SetActive(false);

            if (isLevel7Open == false || isLevel8Open == false || isLevel9Open == false || isLevel10Open == false || isLevel11Open == false || isLevel12Open == false || isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level6Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = true;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;

            }
        }
        

        if (PlayerPrefs.GetInt("Level7Open", 0) == 1)
        {
            isLevel7Open = true;
            lock7.SetActive(false);

            if(isLevel8Open == false || isLevel9Open == false || isLevel10Open == false || isLevel11Open == false || isLevel12Open == false || isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level7Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = true;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;
            }
           

        }
       

        if (PlayerPrefs.GetInt("Level8Open", 0) == 1)
        {
            isLevel8Open = true;
            lock8.SetActive(false);

            if ( isLevel9Open == false || isLevel10Open == false || isLevel11Open == false || isLevel12Open == false || isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level8Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = true;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;
            }


        }
       


        if (PlayerPrefs.GetInt("Level9Open", 0) == 1)
        {
            isLevel9Open = true;
            lock9.SetActive(false);

            if (isLevel10Open == false || isLevel11Open == false || isLevel12Open == false || isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level9Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = true;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;
            }


        }
        


        if (PlayerPrefs.GetInt("Level10Open", 0) == 1)
        {
            isLevel10Open = true;
            lock10.SetActive(false);

            if (isLevel11Open == false || isLevel12Open == false || isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level10Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = true;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;
            }


        }
       


        if (PlayerPrefs.GetInt("Level11Open", 0) == 1)
        {
            isLevel11Open = true;
            lock11.SetActive(false);

            if ( isLevel12Open == false || isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level11Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = true;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;
            }


        }
        

        if (PlayerPrefs.GetInt("Level12Open", 0) == 1)
        {
            isLevel12Open = true;
            lock12.SetActive(false);

            if (isLevel13Open == false || isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level12Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = true;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;
            }


        }
       

        if (PlayerPrefs.GetInt("Level13Open", 0) == 1)
        {
            isLevel13Open = true;
            lock13.SetActive(false);

            if ( isLevel14Open == false || isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level13Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = true;
                level14 = false;
                level15 = false;
                level16 = false;
                levelBoss = false;
            }


        }
        

        if (PlayerPrefs.GetInt("Level14Open", 0) == 1)
        {
            isLevel14Open = true;
            lock14.SetActive(false);

            if ( isLevel15Open == false || isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level14Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = true;
                level15 = false;
                level16 = false;
                levelBoss = false;
            }


        }
        if (PlayerPrefs.GetInt("Level15Open", 0) == 1)
        {
            isLevel15Open = true;
            lock15.SetActive(false);

            if ( isLevel16Open == false || isLevelBossOpen == false)
            {
                car.transform.position = level15Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = true;
                level16 = false;
                levelBoss = false;
            }


        }
        if (PlayerPrefs.GetInt("Level16Open", 0) == 1)
        {
            isLevel16Open = true;
            lock16.SetActive(false);

            if (isLevelBossOpen == false)
            {
                car.transform.position = level16Button.transform.position;
                tutorial = false;
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;
                level5 = false;
                level6 = false;
                level7 = false;
                level8 = false;
                level9 = false;
                level10 = false;
                level11 = false;
                level12 = false;
                level13 = false;
                level14 = false;
                level15 = false;
                level16 = true;
                levelBoss = false;
            }


        }

        if (PlayerPrefs.GetInt("LevelBossOpen", 0) == 1)
        {
            isLevelBossOpen = true;
            lockBoss.SetActive(false);
            car.transform.position = levelBossButton.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = true;
        }
        


        

        if (PlayerPrefs.GetInt("skin") == 1)
        {
            buyButton.interactable = false;
            activeButton.SetActive(false);
            disabledButton.SetActive(true);
            
        }

        if (PlayerPrefs.GetInt("hasDash") == 1)
        {
            //disable Dash buy
            activeDashBuy.SetActive(false);
            disabledDashBuy.SetActive(true);
            buyDashButton.interactable = false;
        }

        if (PlayerPrefs.GetInt("hasRocket", 0) == 1)
        {
            activeRocketBuy.SetActive(false);
            disabledRocketBuy.SetActive(true);
            buyRocketButton.interactable = false;
        }

    }

    // Update is called once per frame
    void Update()

    {
        accept = PlayerPrefs.GetInt("AcceptTA", 0);

        if (sceneName == "Menu")
        {
            if (accept == 0)
            {
                TApanel.SetActive(true);
            }
            if(accept == 1)
            {
                TApanel.SetActive(false);
            }
        }
        score = PlayerPrefs.GetInt("score", 0);

        if (timesBuyDash == 3)
        {
            activeDashBuy.SetActive(false);
            disabledDashBuy.SetActive(true);
            buyDashButton.interactable = false;
            PlayerPrefs.SetInt("hasDash", 1);
        }

        if (PlayerPrefs.GetInt("hasRocket", 0) == 1)
        {
            activeRocketBuy.SetActive(false);
            disabledRocketBuy.SetActive(true);
            buyRocketButton.interactable = false;
        }
        if (PlayerPrefs.GetInt("hasRocket", 0) == 0)
        {
            rocketText.text = "Level: 0";
            
        }
        else
        {
            rocketText.text = "Level: 1";
        }

        dashText.text = "Level: " + PlayerPrefs.GetInt("timesBuyDash", 0);


        if (sceneName == "Store")
        {
            if (PlayerPrefs.GetInt("sadHappyEmoji", 0) == 1)
            {
                sadhappyBuyButton.SetActive(false);

            }
            if (PlayerPrefs.GetInt("prettyEmoji", 0) == 1)
            {
                prettyBuyButton.SetActive(false);

            }
            if (PlayerPrefs.GetInt("cuteEmoji", 0) == 1)
            {
                cuteBuyButton.SetActive(false);

            }

            if(PlayerPrefs.GetInt("skinHippieBought",0) == 1)
            {
                hippieBuyButton.SetActive(false);

            }

            if(PlayerPrefs.GetInt("skinLeopardBought",0) == 1)
            {
                leopardBuyButton.SetActive(false);
            }

            if(PlayerPrefs.GetInt("skinCamoBought",0) == 1)
            {
                camoBuyButton.SetActive(false);
            }
            if (PlayerPrefs.GetInt("skinCamo", 0) == 1)
            {
                skinCamoDisabled.SetActive(true);
                skinLeopardDisabled.SetActive(false);
                skinHippieDisabled.SetActive(false);
                skinBasicDisabled.SetActive(false);


            }
            if (PlayerPrefs.GetInt("skinLeopard", 0) == 1)
            {
                skinCamoDisabled.SetActive(false);
                skinLeopardDisabled.SetActive(true);
                skinHippieDisabled.SetActive(false);
                skinBasicDisabled.SetActive(false);

            }
            if (PlayerPrefs.GetInt("skinHippie",0) == 1)
            {
                skinCamoDisabled.SetActive(false);
                skinLeopardDisabled.SetActive(false);
                skinHippieDisabled.SetActive(true);
                skinBasicDisabled.SetActive(false);

            }
            if (PlayerPrefs.GetInt("skinBasic", 0) == 1)
            {
                skinCamoDisabled.SetActive(false);
                skinLeopardDisabled.SetActive(false);
                skinHippieDisabled.SetActive(false);
                skinBasicDisabled.SetActive(true);
            }


            if(PlayerPrefs.GetInt("sadHappyEmojiApplied", 0) == 1)
            {
                sadhappyDisabled.SetActive(true);
                cuteDisabled.SetActive(false);
                basicEmojiDisabled.SetActive(false);
                prettyDisabled.SetActive(false);
            }
            if (PlayerPrefs.GetInt("prettyEmojiApplied", 0) == 1)
            {
                sadhappyDisabled.SetActive(false);
                cuteDisabled.SetActive(false);
                basicEmojiDisabled.SetActive(false);
                prettyDisabled.SetActive(true);
            }
            if (PlayerPrefs.GetInt("cuteEmojiApplied", 0) == 1)
            {
                sadhappyDisabled.SetActive(false);
                cuteDisabled.SetActive(true);
                basicEmojiDisabled.SetActive(false);
                prettyDisabled.SetActive(false);
            }
            if (PlayerPrefs.GetInt("basicEmojiApplied", 0) == 1)
            {
                sadhappyDisabled.SetActive(false);
                cuteDisabled.SetActive(false);
                basicEmojiDisabled.SetActive(true);
                prettyDisabled.SetActive(false);
            }
        }


    }


    public void QuitGame ()
    {
        Debug.Log ("QUIT!");
        Application.Quit();
    }
    
    public void Store()
    {
        SceneManager.LoadScene("Store");
    }

    public void Tutorial()
    {
        car.transform.position = tutorialButton.transform.position;
        tutorial = true;
        level1 = false;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
        level6 = false;
        level7 = false;
        level8 = false;
        level9 = false;
        level10 = false;
        level11 = false;
        level12 = false;
        level13 = false;
        level14 = false;
        level15 = false;
        level16 = false;
        levelBoss = false;




    }
    public void Level1()
    {
        if (isLevel1Open)
        {
            car.transform.position = level1Button.transform.position;
            tutorial = false;
            level1 = true;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;
        }
        
        


    }
    public void Level2()
    {

        if (isLevel2Open)
        {
            car.transform.position = level2Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = true;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }

        


    }

    public void Level3()
    {
        if (isLevel3Open)
        {
            car.transform.position = level3Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = true;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }
        

    }

    public void Level4()
    {
        if (isLevel4Open)
        {
            car.transform.position = level4Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = true;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }
        


    }
    public void Level5()
    {
        if (isLevel5Open)
        {
            car.transform.position = level5Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = true;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }
        


    }
    public void Level6()
    {
        if (isLevel6Open)
        {
            car.transform.position = level6Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = true;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }
        


    }

    public void Level7()
    {
        if (isLevel7Open)
        {
            car.transform.position = level7Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = true;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }
        

    }
    public void Level8()
    {
        if (isLevel8Open)
        {
            car.transform.position = level8Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = true;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }


    }
    public void Level9()
    {
        if (isLevel9Open)
        {
            car.transform.position = level9Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = true;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }


    }
    public void Level10()
    {
        if (isLevel10Open)
        {
            car.transform.position = level10Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = true;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }


    }
    public void Level11()
    {
        if (isLevel11Open)
        {
            car.transform.position = level11Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = true;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }


    }
    public void Level12()
    {
        if (isLevel12Open)
        {
            car.transform.position = level12Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = true;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }


    }
    public void Level13()
    {
        if (isLevel10Open)
        {
            car.transform.position = level13Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = true;
            level14 = false;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }


    }
    public void Level14()
    {
        if (isLevel14Open)
        {
            car.transform.position = level14Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = true;
            level15 = false;
            level16 = false;
            levelBoss = false;

        }


    }
    public void Level15()
    {
        if (isLevel15Open)
        {
            car.transform.position = level15Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = true;
            level16 = false;
            levelBoss = false;

        }


    }
    public void Level16()
    {
        if (isLevel16Open)
        {
            car.transform.position = level16Button.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = true;
            levelBoss = false;

        }


    }
    public void LevelBoss()
    {
        if (isLevelBossOpen)
        {
            car.transform.position = levelBossButton.transform.position;
            tutorial = false;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            levelBoss = true;

        }
        
    }

    public void DailyChallenges()
    {
        GoldPanel.SetActive(false);
        CosmeticBar.SetActive(false);
        NormalPanel.SetActive(false);
        ChallengePanel.SetActive(true);
    }


    public void faceButton()
    {
        skinContainer.SetActive(false);
        faceContainer.SetActive(true);
    }

    public void skinButton()
    {
        skinContainer.SetActive(true);
        faceContainer.SetActive(false);
    }
    public void PlayGame()
    {
        if(tutorial == true)
        {

            SceneManager.LoadScene("Tutorial");
            
        }

        if(level1 == true)
        {
            if(isLevel1Open)
            {
                SceneManager.LoadScene("1st Level");
            }
        }
        if (level2 == true)
        {
            if (isLevel2Open)
            {
                SceneManager.LoadScene("2nd Level");
            }
        }
        if (level3 == true)
        {
            if (isLevel3Open)
            {
                SceneManager.LoadScene("3rd Level");
            }
        }
        if (level4 == true)
        {
            if (isLevel4Open)
            {
                SceneManager.LoadScene("4th Level");
            }
        }
        if (level5 == true)
        {
            if (isLevel5Open)
            {
                SceneManager.LoadScene("5th Level");
            }
        }
        if (level6 == true)
        {
            if (isLevel6Open)
            {
                SceneManager.LoadScene("6th Level");
            }
        }

        if (level7 == true)
        {
            if (isLevel7Open)
            {
                SceneManager.LoadScene("7th Level");
            }
        }
        if (level8 == true)
        {
            if (isLevel8Open)
            {
                SceneManager.LoadScene("8th Level");
            }
        }
        if (level9 == true)
        {
            if (isLevel9Open)
            {
                SceneManager.LoadScene("9th Level");
            }
        }
        if (level10 == true)
        {
            if (isLevel10Open)
            {
                SceneManager.LoadScene("10th Level");
            }
        }
        if (level11 == true)
        {
            if (isLevel11Open)
            {
                SceneManager.LoadScene("11th Level");
            }
        }
        if (level12 == true)
        {
            if (isLevel12Open)
            {
                SceneManager.LoadScene("12th Level");
            }
        }
        if (level13 == true)
        {
            if (isLevel13Open)
            {
                SceneManager.LoadScene("13th Level");
            }
        }
        if (level14 == true)
        {
            if (isLevel14Open)
            {
                SceneManager.LoadScene("14th Level");
            }
        }
        if (level15 == true)
        {
            if (isLevel15Open)
            {
                SceneManager.LoadScene("15th Level");
            }
        }
        if (level16 == true)
        {
            if (isLevel16Open)
            {
                SceneManager.LoadScene("16th Level");
            }
        }

        if (levelBoss == true)
        {
            if (isLevelBossOpen)
            {
                SceneManager.LoadScene("BossW1 Level");
            }
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
        if(score >= 200)
        {
            timesBuyDash++;
            PlayerPrefs.SetInt("timesBuyDash", timesBuyDash);
            score = score - 200;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();
            dashDmg += 30;
            PlayerPrefs.SetInt("dashDmg", dashDmg);

        }

    }

    public void UpgradeRocket()
    {
        if (score >= 200)
        {
            score = score - 200;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("hasRocket", 1);
            activeRocketBuy.SetActive(false);
            disabledRocketBuy.SetActive(true);
            buyRocketButton.interactable = false;

            
        }
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("skin", 0);
        PlayerPrefs.SetInt("dashDmg", 0);
        PlayerPrefs.SetInt("hasDash", 0);
        PlayerPrefs.SetInt("timesBuyDash", 0);
        PlayerPrefs.SetInt("hasRocket", 0);
        activeDashBuy.SetActive(true);
        disabledDashBuy.SetActive(false);
        buyDashButton.interactable = true;
        activeRocketBuy.SetActive(true);
        disabledRocketBuy.SetActive(false);
        buyRocketButton.interactable = true;
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
        CosmeticBar.SetActive(false);
        NormalPanel.SetActive(false);
        ChallengePanel.SetActive(false);

    }

    public void OpenNormalTickets()
    {
        GoldPanel.SetActive(false);
        NormalPanel.SetActive(true);
        CosmeticBar.SetActive(true);
        ChallengePanel.SetActive(false);

    }

    public void BuyCamoSkin()
    {
        if(score >= 1)
        {
            score = score - 1;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("skinCamoBought", 1);
            camoBuyButton.SetActive(false);

        }
    }
    public void BuyLeopardSkin()
    {
        if (score >= 1)
        {
            score = score - 1;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("skinLeopardBought", 1);
            leopardBuyButton.SetActive(false);
        }
    }
    public void BuyHippieSkin()
    {
        if (score >= 1)
        {
            score = score - 1;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("skinHippieBought", 1);
            hippieBuyButton.SetActive(false);
        }
    }

    public void ApplyCamoSkin()
    {
        PlayerPrefs.SetInt("skinCamo", 1);
        PlayerPrefs.SetInt("skinLeopard", 0);
        PlayerPrefs.SetInt("skinHippie", 0);
        PlayerPrefs.SetInt("skinBasic", 0);

    }

    public void ApplyLeopardSkin()
    {
        PlayerPrefs.SetInt("skinCamo", 0);
        PlayerPrefs.SetInt("skinLeopard", 1);
        PlayerPrefs.SetInt("skinHippie", 0);
        PlayerPrefs.SetInt("skinBasic", 0);

    }
    public void ApplyHippieSkin()
    {
        PlayerPrefs.SetInt("skinCamo", 0);
        PlayerPrefs.SetInt("skinLeopard", 0);
        PlayerPrefs.SetInt("skinHippie", 1);
        PlayerPrefs.SetInt("skinBasic", 0);

    }

    public void ApplyBasicSkin()
    {
        PlayerPrefs.SetInt("skinCamo", 0);
        PlayerPrefs.SetInt("skinLeopard", 0);
        PlayerPrefs.SetInt("skinHippie", 0);
        PlayerPrefs.SetInt("skinBasic", 1);
    }

    public void BuySadHappyEmoji()
    {


        if (score >= 10)
        {
            score = score - 10;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("sadHappyEmoji", 1);
            sadhappyBuyButton.SetActive(false);
        }
        
    }
    public void BuyPrettyEmoji()
    {
        if (score >= 10)
        {
            score = score - 10;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();

            PlayerPrefs.SetInt("prettyEmoji", 1);
            prettyBuyButton.SetActive(false);
        }
    }
    public void BuyCuteEmoji()
    {
        if (score >= 10)
        {
            score = score - 10;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("cuteEmoji", 1);
            cuteBuyButton.SetActive(false);
        }
    }

    public void ApplySadHappyEmoji()
    {
        PlayerPrefs.SetInt("sadHappyEmojiApplied", 1);
        PlayerPrefs.SetInt("prettyEmojiApplied", 0);
        PlayerPrefs.SetInt("cuteEmojiApplied", 0);
        PlayerPrefs.SetInt("basicEmojiApplied", 0);


    }
    public void ApplyPrettyEmoji()
    {
        PlayerPrefs.SetInt("sadHappyEmojiApplied", 0);
        PlayerPrefs.SetInt("prettyEmojiApplied", 1);
        PlayerPrefs.SetInt("cuteEmojiApplied", 0);
        PlayerPrefs.SetInt("basicEmojiApplied", 0);

    }
    public void ApplyCuteEmoji()
    {
        PlayerPrefs.SetInt("sadHappyEmojiApplied", 0);
        PlayerPrefs.SetInt("prettyEmojiApplied", 0);
        PlayerPrefs.SetInt("cuteEmojiApplied", 1);
        PlayerPrefs.SetInt("basicEmojiApplied", 0);

    }

    public void ApplyBasicEmoji()
    {
        PlayerPrefs.SetInt("sadHappyEmojiApplied", 0);
        PlayerPrefs.SetInt("prettyEmojiApplied", 0);
        PlayerPrefs.SetInt("cuteEmojiApplied", 0);
        PlayerPrefs.SetInt("basicEmojiApplied", 1);
    }

    public void ChallengeScroll()
    {
        SceneManager.LoadScene("Store");
    }
}
