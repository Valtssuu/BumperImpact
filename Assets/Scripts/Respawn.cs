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
     void Start ()
     {
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

        if (PlayerHealth.Lives <= 0)
        {
            loseCanvas.SetActive(true);
            Time.timeScale = 0;
            showAd--;

        }


    }
   

     void OnTriggerEnter (Collider col)
     {
         if(col.transform.tag == "Killzone")
         {
            showAd++;
            stars--;

            changeCamera = true;
            player.GetComponent<PlayerController>().camera.fieldOfView = 18;
            MainCamera.GetComponent<CameraController>().distance = 46;
            player.GetComponent<PlayerController>().myBody.velocity = Vector3.zero;

            if (PlayerHealth.Lives <= 30)
              {
                loseCanvas.SetActive(true);
                Time.timeScale = 0;
                showAd--;
              }
              else
              {
                PlayerHealth.Lives = PlayerHealth.Lives - 30;
                //respawn player to Spawnpoint on Object
                this.transform.position = spawnPoint.transform.position;
                this.transform.rotation = Quaternion.identity;
              }
              
         }
         
        if(sceneName == "1st Level" || sceneName == "2nd Level" || sceneName == "3rd Level")
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

        if (col.gameObject.tag == "winTrigger")
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectsWithTag("Enemy2").Length == 0)
            {
                winCanvas.SetActive(true);
                Time.timeScale = 0;

            }
        }
    }

   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "shield" || collision.gameObject.tag == "Enemy2")
        {
            

            Collider myCollider = collision.contacts[0].thisCollider;

            /*if (myCollider.gameObject.name != "PlayerShield")
            {
                PlayerHealth.Lives = PlayerHealth.Lives - 5;

            }
            */



        }
        if(collision.gameObject.tag == "bomb")
        {
            PlayerHealth.Lives = PlayerHealth.Lives - 30;
        }
        if (PlayerHealth.Lives <= 0)
        {
          loseCanvas.SetActive(true);
          Time.timeScale = 0;
          showAd--;

        }

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
 }