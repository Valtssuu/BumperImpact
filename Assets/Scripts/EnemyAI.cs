﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    float eForce;

    //private GameObject updatePoint;

    private Vector3 updatePointPos;

    private float eChaseSpeed = 6.0f;
    Rigidbody eBody;

    NavMeshAgent agent;

    Transform target;

    public Rigidbody playerBody;

    //Vector3 dirDown;

    // Start is called before the first frame update
    void Start()
    {

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
    void FixedUpdate()
    {
        if (enemyLives > enemyStartLives)
        {
            enemyLives = enemyStartLives;
        }

        if (enemyLives <= 0)
        {
            Explode();
            timeManager.DoSlowMotion();

        }

        //check HP to set bump force
        if (enemyLives > 100)
        {
            eForce = 400;
        }

        if (enemyLives <= 100 && enemyLives > 75)
        {
            eForce = 400;
        }

        if (enemyLives <= 75 && enemyLives > 50)
        {
            eForce = 600;
        }

        if (enemyLives <= 50 && enemyLives > 25)
        {
            eForce = 800;
        }

        if (enemyLives <= 25 && enemyLives > 0)
        {
            eForce = 1000;
        }



        //distance from enemy to player
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            
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

        //dirDown = Vector3(0, -1, 0);

        /*RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 3, 0), transform.position + Vector3.down, out hit, 5f))
        {
            Debug.DrawLine(transform.position + new Vector3(0, 3, 0), transform.position + Vector3.down * 10f, Color.cyan);
            Debug.DrawLine(transform.position, hit.point, Color.red);
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.tag == "environment")
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
            }
        }*/

    }

    void Explode()
    {
        GameObject clone = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
        player.GetComponent<PlayerController>().score = player.GetComponent<PlayerController>().score + 1;
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
        yield return new WaitForSeconds(0.2f);
        playerBody.drag = 1;

    }

    private IEnumerator EneNavControl()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = false;


        yield return new WaitForSeconds(1.3f);
        gameObject.GetComponent<NavMeshAgent>().enabled = true;


    }

    private IEnumerator EneDelayDown()
    {
        eBody.AddForce(-direction.up * 15);
        yield return new WaitForSeconds(1f);
        eBody.drag = 1;

    }


}
