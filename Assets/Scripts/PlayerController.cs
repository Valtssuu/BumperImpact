using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    public float moveForce, dashmeter, playerShieldLives, dashspeed;
    public GameObject MainCamera, hitParticle, dashParticle, dashbarover50, shield, Bar, Dust, dash, dashbar, pumpkinSkin;
    public TimeManager timeManager;
    public GameObject TM;
    public Rigidbody myBody;
    public Transform direction = null;
    public int dragAmount;
    public Sprite image;
    SpriteRenderer sprite;
    public Camera camera;
    private bool toohigh;
    public int score;
    // force is how forcefully we will push the player away from the enemy.
    public static float force;
    bool hasShockwaved;
    public float radius = 5f;
    public float ShockwaveForce = 700f;
    public bool boostActivated;
    public GameObject mine;
    public Renderer[] playerMeshChildren;
    public GameObject rocket;
    public int skin;
    public Text scoreText;
    public GameObject shieldButton;
    public GameObject mineButton;
    public GameObject[] PlayerChildren;
    private int mineButtonClicks;
    private int shieldButtonClicks;
    private int rocketButtonClicks;
    public GameObject rocketButton;
    private int itemNumber;
    public string sceneName;

    public float range = 30;
    private string enemyTag = "Enemy";


    public Transform target;

    public float poisonTime;
    void Start()
    {
        InvokeRepeating("addDash", 1.0f, 1f);

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        TM = GameObject.FindWithTag("TimeManager");
        timeManager = TM.GetComponent<TimeManager>();
        myBody = this.GetComponent<Rigidbody>();
        sprite = GetComponent<SpriteRenderer>();
        force = 200;
        toohigh = false;
        //playerShieldLives = shield.GetComponent<SpecialShield>().shieldLives;
        hasShockwaved = false;
        mineButton.SetActive(false);
        rocketButton.SetActive(false);
        shieldButton.SetActive(false);
        //for the updating target
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        mineButtonClicks = 0;
        rocketButtonClicks = 0;
        shieldButtonClicks = 0;
        score = PlayerPrefs.GetInt("score", 0);
        boostActivated = false;
        skin = PlayerPrefs.GetInt("skin", 0);
        if (skin == 1)
        {
            PlayerChildren = GameObject.FindGameObjectsWithTag("PlayerChild");
            foreach(GameObject Child in PlayerChildren)
            {
                Child.SetActive(false);
            }
            
            

            pumpkinSkin.SetActive(true);
        }

    }

    void FixedUpdate()
    {


        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString("");
        //KeepOnTheArena();

        myBody.AddRelativeForce(myBody.transform.TransformDirection(-Vector3.up) * 5);



        //check the position of the joystick and move the player accordingly
        Vector3 moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Vertical"), 0, -CrossPlatformInputManager.GetAxis("Horizontal")) * moveForce;

        if(moveVec != Vector3.zero)
        {
            Dust.SetActive(true);
        }
        else
        {
            Dust.SetActive(false);
        }
        
        //Look at the right direction
        Vector3 lookVec = new Vector3(-CrossPlatformInputManager.GetAxis("Vertical"), 0, CrossPlatformInputManager.GetAxis("Horizontal"));

        //if the joystick is in the middle we dont change the rotation
        if (lookVec != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookVec, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 5);
        }


        //change center of mass if shield is on
        if (shield.activeSelf)
        {
            myBody.centerOfMass = new Vector3(0, 0, 1.85f);

        }
        else
        {
            myBody.ResetCenterOfMass();
        }

        //Keep it on the ground 

        if (this.transform.position.y > 2)
        {
            toohigh = true;
        }
        else
        {
            toohigh = false;
        }

        if(toohigh == true)
        {
            KeepOnTheArena();
        }

        //dashbutton
        bool isBoosting = CrossPlatformInputManager.GetButtonDown("Boost");
        bool stopBoosting = CrossPlatformInputManager.GetButtonUp("Boost");

        //shockwave button
        bool isShockwaving = CrossPlatformInputManager.GetButtonDown("Shockwave");

        //shockwave
        if(isShockwaving == true)
        {
            Shockwave();
            isShockwaving = false;
        }

        

        //dash
        if (dashmeter > 9)
        {
            dashbarover50.SetActive(true);
            if (isBoosting == true)
            {
                
                myBody.AddForce(-direction.forward * dashspeed);
                dashmeter -= 10;
                //dash.SetActive(true);
                GameObject clone = (GameObject)Instantiate(dashParticle, transform.position, transform.rotation);
                clone.transform.parent = gameObject.transform;
                Destroy(clone, 0.2f);
                StartCoroutine(StopBoosting());

                boostActivated = true;
            }

        }
        else
        {
            dashbarover50.SetActive(false);
            

        }
       if(isBoosting == false)
        {
           
            dash.SetActive(false);
            
        }

        
        
        //adding force to the player based on the position of the joystick
        myBody.AddForce(moveVec);

        

        force = 800;

        //do nothing if no target is found for missile
        if (target == null)
        {
            return;
        }
    }

    private void Shockwave()
    {



        //effect
        //Instantiate(shockwaveEffect, transform.position, transform.rotation);


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();


            if (rb != null && rb != myBody)
            {

                rb.AddExplosionForce(ShockwaveForce, transform.position, radius);
                rb.drag = 5;

            }

        }

        

    }
    private void KeepOnTheArena()
    {
        myBody.AddRelativeForce(myBody.transform.TransformDirection(-Vector3.up) * 100);

    }



    void addDash()
    {
        dashmeter += 1;
    }
    
    //add value to dashmeter upon collision
    private void OnCollisionEnter(Collision other)
    {

        dashmeter = Mathf.Clamp(dashmeter, 0, 10);

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2") || other.gameObject.CompareTag("Boss1"))
        {
            if(boostActivated == true)
            {
                if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2"))
                {
                    dashmeter += 10;
                    myBody.velocity = Vector3.zero;
                }
                
            }

            else
            {
                PlayerHealth.Lives = PlayerHealth.Lives - 5;

                dashmeter += 2;
            }
            GameObject clone = (GameObject)Instantiate(hitParticle, other.contacts[0].point, Quaternion.identity);
                    Destroy(clone, 0.2f);

            Collider myCollider = other.contacts[0].thisCollider;



            if (myCollider.gameObject.name == "PlayerShield")
            {
                playerShieldLives -= 25;
                Debug.Log(playerShieldLives);

                if (playerShieldLives == -75)
                {
                    shield.SetActive(false);
                    playerShieldLives = 0;
                }

            }

            

        }

        /*if (other.gameObject.CompareTag("EnemyShield"))
        {
            Vector3 pDir = other.contacts[0].point - transform.position;
            Vector3 playerDir = -pDir.normalized;
            myBody.AddForce(playerDir * 10000);
        }*/





    }

 


    //delay before changing the drag
    private IEnumerator StopBoosting()
    {
        yield return new WaitForSeconds(0.1f);
        myBody.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        boostActivated = false;
        
    }
    
   
    private IEnumerator DelayHitParticle()
    {
        yield return new WaitForSeconds(0.1f);

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("50Fov"))
        {
            if (camera.fieldOfView == 18)
            {
                StartCoroutine("ZoomOut");
            }

        }
        if (other.gameObject.CompareTag("BackToNormal"))
        {
            if (camera.fieldOfView == 38)
            {
                StartCoroutine("ZoomIn");
            }

        }

        if (other.gameObject.tag == "RealItems")
        {
            if (mineButton.activeInHierarchy == false && rocketButton.activeInHierarchy == false && shieldButton.activeInHierarchy == false)
            {
                itemNumber = Random.Range(0, 3);

            //Debug.Log(itemNumber);
            if (itemNumber == 0)
            {
                mineButton.SetActive(true);
            }

            if (itemNumber == 1)
            {
                rocketButton.SetActive(true);
            }
            if (itemNumber == 2)
            {
                shieldButton.SetActive(true);
            }

            Destroy(other.gameObject);
            }

            
        }
        if(other.gameObject.tag == "MoreDash")
        {
            if(dashmeter == 1)
            {
                dashmeter += 5;

            }
            if(dashmeter == 2)
            {
                dashmeter += 4;
            }
            if(dashmeter == 3)
            {
                dashmeter += 3;
            }
            Destroy(other.gameObject);
        }



    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PoisonArea")
        {
            poisonTime -= Time.deltaTime;
            moveForce = 20;
            if (poisonTime <= 0)
            {
                PlayerHealth.Lives -= 5;
                poisonTime = 1.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PoisonArea")
        {
            moveForce = 30;
        }
    }

    public void OnSpecialButtonClicked()
    {
        if (shieldButton.activeSelf)
        {
            shield.SetActive(true);
            shieldButton.SetActive(false);
        }
        
        if (mineButton.activeSelf)
        {

                Instantiate(mine, transform.position, transform.rotation);
                mineButtonClicks++;
                mineButton.SetActive(false);
        }

        if (rocketButton.activeSelf)
        {
            //if bought the upgrade
            //Instantiate(rocket, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0)));
            //You picked the rockets
            if (PlayerPrefs.GetInt("hasRocket", 0) == 1)
            {
                if (target != null)
                {
                    if (rocketButtonClicks <= 3)
                    {
                        Instantiate(rocket, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0)));
                        rocketButtonClicks++;
                    }
                    if (rocketButtonClicks == 3)
                    {
                        rocketButton.SetActive(false);
                        rocketButtonClicks = 0;
                    }
                }
                else
                {
                    return;
                }
            } else
            {
                if (rocketButtonClicks <= 3)
                {
                    Instantiate(rocket, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0)));
                    rocketButtonClicks++;
                }
                if (rocketButtonClicks == 3)
                {
                    rocketButton.SetActive(false);
                    rocketButtonClicks = 0;
                }
            }
            

        }

    }

    private IEnumerator ZoomOut()
    {
        for (int i = 30; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            camera.fieldOfView++;
            MainCamera.GetComponent<CameraController>().distance--;
        }

    }
    private IEnumerator ZoomIn()
    {
        for (int i = 50; i > 30; i--)
        {
            yield return new WaitForSeconds(0.01f);
            camera.fieldOfView--;
            MainCamera.GetComponent<CameraController>().distance++;
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("Enemy2");
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss1");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        foreach (GameObject enemy2 in enemies2)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy2.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy2;
            }
        }

        foreach (GameObject boss in bosses)
        {
            float distanceToBoss = Vector3.Distance(transform.position, boss.transform.position);
            if (distanceToBoss < shortestDistance)
            {
                shortestDistance = distanceToBoss;
                nearestEnemy = boss;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
