using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyAI : MonoBehaviour
{
    public int enemyLives;

    public int enemyStartLives = 100;
    public float lookRadius = 15f;
    public GameObject explosion;
    public Transform direction = null;
    public GameObject player;
    public TimeManager timeManager;
    public GameObject TM;
    float poisonTimeE;
    bool toohigh;
    float eForce;

    //private GameObject updatePoint;

    private Vector3 updatePointPos;

    Rigidbody eBody;

    NavMeshAgent agent;
    public string sceneName;

    Transform target;

    public Rigidbody playerBody;

    //Vector3 dirDown;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        TM = GameObject.FindWithTag("TimeManager");
        timeManager = TM.GetComponent<TimeManager>();
        player = GameObject.FindWithTag("Player");
        enemyLives = enemyStartLives;
        
        eBody = this.GetComponent<Rigidbody>();

        //find target according to PlayerManager script
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();

        //enemy will find updatePoint at start
        //updatePoint = GameObject.Find("updatePoint");

        this.GetComponent<Patrol>().enabled = true;

        playerBody = target.GetComponent<Rigidbody>();

        //playerBody.GetComponent<PlayerController>().myBody;
        enemyLives = enemyStartLives;
        lookRadius = 15f;
    }

    // Update is called once per frame
    void Update()
    {

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

        if (enemyLives > enemyStartLives)
        {
            enemyLives = enemyStartLives;
        }

        if (enemyLives <= 0)
        {
            Explode();

        }

        //check HP to set bump force

        if (enemyLives > 75)
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

        

        //distance from enemy to player
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.enabled = true;
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
            if (sceneName == "16th Level")
            {
                agent.enabled = false;
            }


        }

        //dirDown = Vector3(0, -1, 0);

        /*RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 2, 0), transform.position + Vector3.down, out hit, 20f))
        {
            Debug.DrawLine(transform.position + new Vector3(0, 2, 0), transform.position + Vector3.down * 20f, Color.cyan);
            //Debug.DrawLine(transform.position, hit.point, Color.red);
            if (hit.collider.tag == "Killzone")
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = true;
            }
        }*/

    }

    void Explode()
    {
        GameObject clone = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
        player.GetComponent<PlayerController>().score = player.GetComponent<PlayerController>().score + 1;
        timeManager.DoSlowMotion();

        if(sceneName == "Endless level")
        {
            PlayerPrefs.SetInt("endlessKills", PlayerPrefs.GetInt("endlessKills") + 1);
        }

        Destroy(gameObject);
        Destroy(clone, 1f);



    }
    void OnCollisionEnter(Collision collision)
    {

        

        if (collision.gameObject.tag == "Player")
        {
            lookRadius = Mathf.Infinity;
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

            if(player.GetComponent<PlayerController>().boostActivated == true)
            {
                enemyLives = enemyLives - PlayerPrefs.GetInt("dashDmg", 0);

            }

            enemyLives = enemyLives - 30;

        }

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
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
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
        
        yield return new WaitForSeconds(0.1f);
        playerBody.drag = 1;

    }

    private IEnumerator EneNavControl()
    {
        agent.enabled = false;


        yield return new WaitForSeconds(1.3f);

        agent.enabled = true;
        eBody.drag = 1;


    }
    private void KeepOnTheArena()
    {
        eBody.AddRelativeForce(eBody.transform.TransformDirection(-Vector3.up) * 100);

    }
}
