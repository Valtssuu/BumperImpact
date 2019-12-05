using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NewEnemyAI : MonoBehaviour
{
    public int enemyLives;

    public int enemyStartLives = 100;
    public float lookRadius = 15f;
    public GameObject explosion;
    public Transform direction = null;
    public GameObject ticket;
    public Transform WhereToLook;

    public GameObject shield, player;
    public float shieldLives;
    private bool toohigh;
    float poisonTimeE;
    GameObject enemy;

    public string sceneName;

    //public GameObject player;

    float eForce;

    //private GameObject updatePoint;

    private Vector3 updatePointPos;

    private float eChaseSpeed = 6.0f;

    Rigidbody eBody;

    NavMeshAgent agent;

    Transform target;

    public Rigidbody playerBody;

    // Start is called before the first frame update
    void Start()
    {
        WhereToLook = GameObject.FindWithTag("WhereToLook").GetComponent<Transform>();

        enemy = this.gameObject;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        enemyLives = enemyStartLives;
        shieldLives = 100;

        player = GameObject.FindWithTag("Player");

        target = player.transform;

        eBody = this.GetComponent<Rigidbody>();

        //find target according to PlayerManager script
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();

        //enemy will find updatePoint at start
        //updatePoint = GameObject.Find("updatePoint");

        this.GetComponent<Patrol>().enabled = true;

        playerBody = target.GetComponent<Rigidbody>();

        eBody.centerOfMass = new Vector3(0, 0, 1.85f);
        player = GameObject.FindWithTag("Player");
        if(shieldLives <= 0)
        {
            eBody.ResetCenterOfMass();
        }

        //playerBody.GetComponent<PlayerController>().myBody;

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyLives > enemyStartLives)
        {
            enemyLives = enemyStartLives;
        }

        if (enemyLives <= 0)
        {
            Explode();
        }

        //check HP to set bump force
        if (enemyLives <= 100 && enemyLives > 75)
        {
            eForce = 200;
        }

        if (enemyLives <= 75 && enemyLives > 50)
        {
            eForce = 300;
        }

        if (enemyLives <= 50 && enemyLives > 25)
        {
            eForce = 400;
        }

        if (enemyLives <= 25 && enemyLives > 0)
        {
            eForce = 500;
        }

        if (this.transform.position.y > 2)
        {
            toohigh = true;
        }
        else
        {
            toohigh = false;
        }

        if (toohigh == true)
        {
            KeepOnTheArena();
        }

        //distance from enemy to player
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            //lookRadius = 9999f;
            //disable patrol script
            this.GetComponent<Patrol>().enabled = false;
            //chase player
            agent.SetDestination(target.position);

            //updatePointPos = new Vector3(updatePoint.transform.position.x, transform.position.y, updatePoint.transform.position.z);
            //Here, the enemy will follow the waypoint.
            //transform.position = Vector3.MoveTowards(transform.position, updatePointPos, eChaseSpeed * Time.deltaTime);

            if (distance <= agent.stoppingDistance)
            {
                //face the target
                FaceTarget();
            }

        }

        else
        {
            this.GetComponent<Patrol>().enabled = true;
        }

    }

    public void Explode()
    {
        GameObject clone = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
        GameObject clone2 = (GameObject)Instantiate(ticket, enemy.transform.position, transform.rotation);
        player.GetComponent<PlayerController>().score = player.GetComponent<PlayerController>().score + 2;
        clone2.transform.LookAt(WhereToLook);
        clone2.GetComponent<Rigidbody>().AddForce(transform.up * 8);
        if (sceneName == "Endless level")
        {
            PlayerPrefs.SetInt("endlessKills", PlayerPrefs.GetInt("endlessKills") + 1);
        }
        Destroy(gameObject);
        Destroy(clone, 1f);
        Destroy(clone2, 0.4f);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PoisonArea")
        {
            poisonTimeE -= Time.deltaTime;
            if (poisonTimeE <= 0)
            {
                enemyLives -= 5;
                poisonTimeE = 1.0f;
            }
        }
    }

    private void KeepOnTheArena()
    {
        eBody.AddForce(eBody.transform.TransformDirection(-Vector3.up) * 50);

    }
    void OnCollisionEnter(Collision collision)
    {
       
        
        

        if (collision.gameObject.tag == "Player")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = collision.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            Vector3 edir = -dir.normalized;
            //normal vetor for player pushback
            Vector3 pdir = dir.normalized;


            StartCoroutine(EneDelayBump(edir));

            //playerBody.AddForce(pdir*PlayerController.force);

            StartCoroutine(PlayerDelayBump(pdir));

            StartCoroutine(EneNavControl());

            Collider myCollider = collision.contacts[0].thisCollider;



            if (myCollider.gameObject.name == "shield")
            {
                PlayerController.force = 1000; //kysy thanhiltä

                shieldLives -= 25;
                if (shieldLives == 0)
                {

                    Destroy(shield);
                }

            }

            else
            {
                enemyLives -= 30;
                if (player.GetComponent<PlayerController>().boostActivated == true)
                {
                    enemyLives = enemyLives - PlayerPrefs.GetInt("dashDmg", 0);

                }
            }

            if (enemyLives <= 0)
            {
                Explode();
            }

        }

    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Killzone")
        {
            Explode();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    //draw the look range (touch range) of the enemy in Red
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public IEnumerator EneDelayBump(Vector3 edir)
    {


        // Add force in the direction of dir and multiply it by force. 
        // This will push back the player
        eBody.AddForce(edir * eForce);
        yield return new WaitForSeconds(0.1f);
        eBody.drag = 1;
    }

    public IEnumerator PlayerDelayBump(Vector3 pdir)
    {
        playerBody.AddForce(pdir * PlayerController.force);
        yield return new WaitForSeconds(0.2f);
        playerBody.drag = 1000;
        yield return new WaitForSeconds(0.1f);
        playerBody.drag = 1;
    }

    private IEnumerator EneNavControl()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = false;


        yield return new WaitForSeconds(1.2f);
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        eBody.drag = 1;

    }


}
