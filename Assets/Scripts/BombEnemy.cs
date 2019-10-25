﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BombEnemy : MonoBehaviour
{
    public int enemyLives;

    public int enemyStartLives = 100;
    public float lookRadius = 15f;
    public GameObject explosion;
    public Transform direction = null;
    public GameObject bomb;
    public GameObject player;

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
        enemyLives = enemyStartLives;

        eBody = this.GetComponent<Rigidbody>();

        //find target according to PlayerManager script
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();

        //enemy will find updatePoint at start
        //updatePoint = GameObject.Find("updatePoint");

        this.GetComponent<Patrol>().enabled = true;
        player = GameObject.FindWithTag("Player");
        playerBody = target.GetComponent<Rigidbody>();

        //playerBody.GetComponent<PlayerController>().myBody;

        InvokeRepeating("InstantiateBombs", 2.0f, 4f);
        InvokeRepeating("Stop", 1.0f, 4f);
        InvokeRepeating("Continue", 3.0f, 4f);
        InvokeRepeating("DestroyBombClones", 3.5f, 4f);



    }

    // Update is called once per frame
    void Update()
    {
        if (enemyLives > enemyStartLives)
        {
            enemyLives = enemyStartLives;
        }



        //check HP to set bump force
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

        FaceTarget();
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

    void Explode()
    {
        GameObject clone = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
        player.GetComponent<PlayerController>().score = player.GetComponent<PlayerController>().score + 2;
        Destroy(gameObject);
        Destroy(clone, 1f);
    }
    void OnCollisionEnter(Collision collision)
    {

        if (enemyLives < 0)
        {
            Explode();
        }

        if (collision.gameObject.tag == "Player")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = collision.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            Vector3 edir = -dir.normalized;
            //normal vetor for player pushback
            Vector3 pdir = dir.normalized;


            //StartCoroutine(EneDelayBump(edir));

            //playerBody.AddForce(pdir*PlayerController.force);

            StartCoroutine(PlayerDelayBump(pdir));

            //StartCoroutine(EneNavControl());


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
    
    void InstantiateBombs()
    {
       
        GameObject clone = (GameObject)Instantiate(bomb, transform.position + new Vector3(0, 1, 0), transform.rotation);
        Rigidbody BombRb = clone.GetComponent<Rigidbody>();
        Physics.IgnoreCollision(clone.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        BombRb.AddForce(transform.forward * 800);

    }

    void Stop()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameObject.GetComponent<Patrol>().enabled = false;
    }
    void Continue()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        gameObject.GetComponent<Patrol>().enabled = true;
    }

    void DestroyBombClones()
    {
        Destroy(GameObject.FindWithTag("bomb"));
    }

}
