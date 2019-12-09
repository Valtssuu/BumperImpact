using UnityEngine;
 using System.Collections;
 using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
 
 public class Respawn : MonoBehaviour {
 
     public GameObject spawnPoint;
     private int showAd;
     public GameObject loseCanvas;
    public GameObject gameManager;
    //bool winTrigger;
    public int stars;
    public bool changeCamera;
    [SerializeField] private Animator BridgeController;
    [SerializeField] private Animator Bridge2Controller;
    [SerializeField] private Animator Bridge3Controller;
    [SerializeField] private Animator BridgeBoss1Controller;
    [SerializeField] private Animator BridgeBoss2Controller;
    [SerializeField] private Animator HPBarController;
    public bool allFreeze;
    bool hint1Shown, hint2Shown, hint3Shown, hint4Shown, hint5Shown;

    
    public GameObject hint1TriggerObj, hint2TriggerObj, hint3TriggerObj, hint4TriggerObj;

    public GameObject hint1, hint2, hint3, hint4, hint5, hintTemplate;

    Rigidbody myBody;

    public GameObject winCanvas;

    public GameObject Bridge;

    public GameObject Bridge2;

    public GameObject player;

    public GameObject shield;

    public GameObject MainCamera;

    public GameObject cameraBridge1, cameraBridge2;

    public GameObject hintCanvas;

    public GameObject pausePanel;

    public string sceneName;

    public int sessionScore;

    int score;
     void Start ()
     {
        if(sceneName == "tutorial")
        {
            hintTemplate.SetActive(false);
            hint1.SetActive(false);
            hint2.SetActive(false);
            hint3.SetActive(false);
            hint4.SetActive(false);
            hint5.SetActive(false);
        }
        
        score = PlayerPrefs.GetInt("score", 0);
        sessionScore = score;

        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        Time.timeScale = 1;
        myBody = this.GetComponent<Rigidbody>();
        
        
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        showAd = PlayerPrefs.GetInt("showAd", 0);
        //winTrigger = false;

        if (sceneName != "Endless level" && sceneName != "BossW1 Level")
        {
            cameraBridge1.SetActive(false);
            cameraBridge2.SetActive(false);
        }

        stars = 3;


    }

    void Update ()
     {
        PlayerPrefs.SetInt("showAd", showAd);
       

       if (sceneName != "Endless level" && sceneName != "BossW1 Level")
        {
            if (GameObject.FindGameObjectsWithTag("Enemy1").Length == 0)
            {

                BridgeController.SetBool("BridgeUp", true);
                cameraBridge1.SetActive(true);

            }

            if (GameObject.FindGameObjectsWithTag("Enemy1A2").Length == 0)
            {
                Bridge2Controller.SetBool("BridgeUp", true);
                //Bridge2.SetActive(true);
                cameraBridge2.SetActive(true);
            }

            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectsWithTag("Enemy2").Length == 0)
            {
                Bridge3Controller.SetBool("BridgeUp", true);
                
            }

            
        }

       if(sceneName == "BossW1 Level")
        {
            if(GameObject.FindGameObjectsWithTag("Boss1").Length == 0)
            {
                BridgeBoss2Controller.SetBool("BridgeUp", true);
            }
        }

        if (PlayerHealth.Lives <= 0)
        {
            loseCanvas.SetActive(true);

            myBody.velocity = Vector3.zero;
            myBody.constraints = RigidbodyConstraints.FreezeAll;
            showAd--;

        }


    }
   

     void OnTriggerEnter (Collider col)
     {

        if(col.transform.tag == "bridgeDownBoss")
        {
            BridgeBoss1Controller.SetBool("BridgeDown", true);
        }


         if(col.transform.tag == "Killzone")
         {
            showAd++;
            stars--;

            changeCamera = true;
            if(sceneName != "BossW1 Level")
            {
                player.GetComponent<PlayerController>().MainCamera.GetComponent<Camera>().fieldOfView = 18;
                MainCamera.GetComponent<CameraController>().distance = 46;
                

            }
           

            player.GetComponent<PlayerController>().myBody.velocity = Vector3.zero;

            if (PlayerHealth.Lives <= 30)
              {
                loseCanvas.SetActive(true);
                myBody.velocity = Vector3.zero;
                myBody.constraints = RigidbodyConstraints.FreezeAll;

                showAd--;
              }
              else
              {
                PlayerHealth.Lives = PlayerHealth.Lives - 30;
                StartCoroutine("hpBar");

                //respawn player to Spawnpoint on Object
                this.transform.position = spawnPoint.transform.position;
                this.transform.rotation = Quaternion.identity;
              }
              
         }
         
        if(sceneName == "1st Level"  )
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(82.7f, 1.7f, -92.5f);
            }
            if (col.gameObject.tag == "SpawnPoint2")
            {
                spawnPoint.transform.position = new Vector3(181, 1.8f, -94.3f);

            }
        }

        if(sceneName == "2nd Level" || sceneName == "3rd Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(82.7f, 1.7f, -92.5f);
            }
            if (col.gameObject.tag == "SpawnPoint2")
            {
                spawnPoint.transform.position = new Vector3(193, 1.8f, -94.3f);

            }
        }
        if(sceneName == "4th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(130f, 2.7999999f, -93.4f);
            }
            if (col.gameObject.tag == "SpawnPoint2")
            {
                spawnPoint.transform.position = new Vector3(270f, 1.8f, -94.3f);

            }
        }

        if (sceneName == "5th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(90f, 2.7999999f, -93.4f);
            }
            if (col.gameObject.tag == "SpawnPoint2")
            {
                spawnPoint.transform.position = new Vector3(153f, 1.8f, -94.3f);

            }
        }



        if (sceneName == "6th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(153.6f, 2.7999999f, -93.4f);
            }
            if (col.gameObject.tag == "SpawnPoint2")
            {
                spawnPoint.transform.position = new Vector3(299.5f, 1.8f, -137f);

            }
        }
        if (sceneName == "7th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(113.7f, 2.7999999f, -130f);
            }
            if (col.gameObject.tag == "SpawnPoint2")
            {
                spawnPoint.transform.position = new Vector3(275.2f, 1.8f, -130f);

            }
        }
        if (sceneName == "8th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(34.4f, 2.799999f, -217.9f);
            }
            if (col.gameObject.tag == "SpawnPoint2")
            {
                spawnPoint.transform.position = new Vector3(130f, 2.799999f, -243.2f);

            }
        }
        if (sceneName == "9th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(130.1f, 2.7999999f, -92.8f);
            }
        }
        if (sceneName == "10th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(129.2f, 2.7999999f, -92.1f);
            }
        }
        if (sceneName == "11th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(128.5f, 2.7999999f, -152.1f);
            }
        }
        if (sceneName == "12th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(128.1f, 2.7999999f, -92.1f);
            }
            if (col.gameObject.tag == "SpawnPoint2")
            {
                spawnPoint.transform.position = new Vector3(287.3f, 2.799999f, -92.1f);

            }
        }
        if (sceneName == "13th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(197.3f, 2.7999999f, -92.1f);
            }
        }
        if (sceneName == "14th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(207.6f, 2.7999999f, -92.1f);
            }
        }
        if (sceneName == "15th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(179.8f, 2.7999999f, -92.1f);
            }
        }
        if (sceneName == "16th Level")
        {
            if (col.gameObject.tag == "SpawnPoint1")
            {
                spawnPoint.transform.position = new Vector3(127.1f, 2.7999999f, -92.1f);
            }
        }

        if (col.gameObject.tag == "winTrigger")
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectsWithTag("Enemy2").Length == 0 && GameObject.FindGameObjectsWithTag("Boss1").Length == 0)
            {
                winCanvas.SetActive(true);
                myBody.velocity = Vector3.zero;
                myBody.constraints = RigidbodyConstraints.FreezeAll;

                sessionScore = PlayerPrefs.GetInt("score",0) - sessionScore;
                Debug.Log(sessionScore);

            }
            if(stars == 3)
            {
                PlayerPrefs.SetInt("threeStars", 1);
            }

            if(sceneName == "tutorial")
            {
                PlayerPrefs.SetInt("Level1Open", 1);
            }
            if (sceneName == "1st Level")
            {
                PlayerPrefs.SetInt("Level2Open", 1);
            }
            if (sceneName == "2nd Level")
            {
                PlayerPrefs.SetInt("Level3Open", 1);
            }
            if (sceneName == "3rd Level")
            {
                PlayerPrefs.SetInt("Level4Open", 1);
            }
            if (sceneName == "4th Level")
            {
                PlayerPrefs.SetInt("Level5Open", 1);
            }
            if (sceneName == "5th Level")
            {
                PlayerPrefs.SetInt("Level6Open", 1);
            }
            if (sceneName == "6th Level")
            {
                PlayerPrefs.SetInt("Level7Open", 1);
            }
            if (sceneName == "7th Level")
            {
                PlayerPrefs.SetInt("Level8Open", 1);
            }
            if (sceneName == "8th Level")
            {
                PlayerPrefs.SetInt("Level9Open", 1);
            }
            if (sceneName == "9th Level")
            {
                PlayerPrefs.SetInt("Level10Open", 1);
            }
            if (sceneName == "10th Level")
            {
                PlayerPrefs.SetInt("Level11Open", 1);
            }
            if (sceneName == "11th Level")
            {
                PlayerPrefs.SetInt("Level12Open", 1);
            }
            if (sceneName == "12th Level")
            {
                PlayerPrefs.SetInt("Level13Open", 1);
            }
            if (sceneName == "13th Level")
            {
                PlayerPrefs.SetInt("Level14Open", 1);
            }
            if (sceneName == "14th Level")
            {
                PlayerPrefs.SetInt("Level15Open", 1);
            }
            if (sceneName == "15th Level")
            {
                PlayerPrefs.SetInt("Level16Open", 1);
            }
            if (sceneName == "16th Level")
            {
                PlayerPrefs.SetInt("LevelBossOpen", 1);
            }
            if (sceneName == "BossW1 Level")
            {
                PlayerPrefs.SetInt("bossDefeated", 1);
                player.GetComponent<PlayerController>().score += 50;
                PlayerPrefs.SetInt("score", player.GetComponent<PlayerController>().score);
                player.GetComponent<PlayerController>().scoreText.text = player.GetComponent<PlayerController>().score.ToString("");
            }

        }
        if(sceneName == "tutorial")
        {
            if (col.gameObject.tag == "Hint1Trigger")
            {
                hint1Trigger();


            }
            if (col.gameObject.tag == "Hint2Trigger")
            {
                hint2Trigger();

            }
            if (col.gameObject.tag == "Hint3Trigger")
            {
                hint3Trigger();

            }
            if (col.gameObject.tag == "Hint4Trigger")
            {
                hint4Trigger();

            }

            if (col.gameObject.tag == "Hint5Trigger")
            {
                hint5Trigger();

            }
        }
       
        
    }

   


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "shield" || collision.gameObject.tag == "Enemy2")
        {
            

            Collider myCollider = collision.contacts[0].thisCollider;

        }
        if(collision.gameObject.tag == "bomb")
        {
            PlayerHealth.Lives = PlayerHealth.Lives - 30;
            StartCoroutine("hpBar");

        }
        if (PlayerHealth.Lives <= 0)
        {
        loseCanvas.SetActive(true);
        myBody.velocity = Vector3.zero;
        myBody.constraints = RigidbodyConstraints.FreezeAll;
        showAd--;

        }

    }
    private IEnumerator hpBar()
    {
        HPBarController.SetBool("HpAnim", true);
        yield return new WaitForSeconds(0.1f);
        HPBarController.SetBool("HpAnim", false);

    }
    public void OnReplayButtonClicked() 
     {
		//activate movement of the player
		//hide replay button
		//load the scene again
		//SceneManager.LoadScene("Game");
        SceneManager.LoadScene(sceneName);
		Time.timeScale = 1;

        if (showAd % 2 == 0)
        {
            if (Advertisement.IsReady("video"))
            {
                Advertisement.Show("video");
            }
        }
    }

     public void OnQuitButtonClicked ()
     {
         //go to menu
         SceneManager.LoadScene("Menu");
         Time.timeScale = 1;
     }

    public void OnContinueClicked()
    {
        Time.timeScale = 1;
        hintCanvas.SetActive(false);
    }

    public void OnNextLevelClicked()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("WorldMap");
    }

    public void Pause()
    {

        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(sceneName);
    }


    public void hintPanelContinue()
    {
        hint1.SetActive(false);
        hint2.SetActive(false);
        hint3.SetActive(false);
        hint4.SetActive(false);
        hintTemplate.SetActive(false);
        allFreeze = false;
        myBody.constraints = RigidbodyConstraints.None;
        myBody.constraints = RigidbodyConstraints.FreezeRotation;


    }
   

    public void hint1Trigger()
    {
        if(hint1Shown == false)
        {
            hintTemplate.SetActive(true);
            hint1.SetActive(true);
            allFreeze = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;
        }
        
        hint1Shown = true;
    }
    public void hint2Trigger()
    {
        if (hint2Shown == false)
        {
            hintTemplate.SetActive(true);
            hint2.SetActive(true);
            allFreeze = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;
        }
        hint2Shown = true;
    }
    public void hint3Trigger()
    {
        if (hint3Shown == false)
        {
            hintTemplate.SetActive(true);
            hint3.SetActive(true);
            allFreeze = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;
        }
        hint3Shown = true;
    }
    public void hint4Trigger()
    {
        if (hint4Shown == false)
        {
            hintTemplate.SetActive(true);
            hint4.SetActive(true);
            allFreeze = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;

        }
        hint4Shown = true;
    }
    public void hint5Trigger()
    {
        if (hint5Shown == false)
        {
            hintTemplate.SetActive(true);
            hint5.SetActive(true);
            allFreeze = true;
            myBody.constraints = RigidbodyConstraints.FreezeAll;

        }
        hint5Shown = true;
    }
    
}