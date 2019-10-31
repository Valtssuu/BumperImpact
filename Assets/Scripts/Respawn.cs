using UnityEngine;
 using System.Collections;
 using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
 
 public class Respawn : MonoBehaviour {
 
     public GameObject spawnPoint;
     private int showAd;
     public GameObject loseCanvas;
    public GameObject gameManager;

    [SerializeField] private Animator BridgeController;
    [SerializeField] private Animator Bridge2Controller;

    Rigidbody myBody;

    public GameObject winCanvas;

    public GameObject Bridge;

    public GameObject Bridge2;

    public GameObject player;

    public GameObject shield;

    public GameObject MainCamera;

    public GameObject cameraBridge1, cameraBridge2;

    public GameObject hintCanvas;

    public string sceneName;
     void Start ()
     {
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        Time.timeScale = 1;
        myBody = this.GetComponent<Rigidbody>();
        cameraBridge1.SetActive(false);
        cameraBridge2.SetActive(false);
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        showAd = PlayerPrefs.GetInt("showAd", 0);
        

    }

    void Update ()
     {
        PlayerPrefs.SetInt("showAd", showAd);
       

       if (sceneName != "Endless level")
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
                winCanvas.SetActive(true);
                Time.timeScale = 0;

            }
        }

        if (PlayerHealth.Lives <= 0)
        {
            loseCanvas.SetActive(true);
            Time.timeScale = 0;
            if (showAd % 2 == 0)
            {
                if (Advertisement.IsReady("video"))
                {
                    Advertisement.Show("video");
                }
            }

        }


    }
   
     void OnTriggerEnter (Collider col)
     {
         if(col.transform.tag == "Killzone")
         {
            showAd++;

            player.GetComponent<PlayerController>().camera.fieldOfView = 18;
            MainCamera.GetComponent<CameraController>().distance = 46;
            player.GetComponent<PlayerController>().myBody.velocity = Vector3.zero;
            Debug.Log(showAd);
            if (PlayerHealth.Lives <= 30)
              {
                if(showAd%2 == 0)
                {
                    if (Advertisement.IsReady("video"))
                    {
                        Advertisement.Show("video");
                    }
                }

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
         if(col.gameObject.tag == "SpawnPoint1")
         {
            spawnPoint.transform.position = new Vector3(68, 1.5f, -143);
         }
         if(col.gameObject.tag == "SpawnPoint2")
        {
            spawnPoint.transform.position = new Vector3(167, 1.5f, -143);

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
            PlayerHealth.Lives = PlayerHealth.Lives - 50;
        }
        if (PlayerHealth.Lives <= 0)
        {
          loseCanvas.SetActive(true);
          Time.timeScale = 0;
            if (showAd % 2 == 0)
            {
                if (Advertisement.IsReady("video"))
                {
                    Advertisement.Show("video");
                }
            }
            
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
        SceneManager.LoadScene("Level2");
    }
 }