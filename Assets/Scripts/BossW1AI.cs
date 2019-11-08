﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossW1AI : MonoBehaviour
{
    public int boss1Lives;

    public int boss1StartLives = 1000;
    public float lookRadius;
    public GameObject explosion;
    public Transform direction = null;
    public GameObject bomb;
    public GameObject player;

    float boss1Speed = 8f;

    float eForce;

    private float eChaseSpeed = 6.0f;

    Rigidbody eBody;

    NavMeshAgent agent;

    Transform target;

    public Rigidbody playerBody;

    public enum ElectricState { ELECTRIC, NORMAL};

    private ElectricState state = ElectricState.NORMAL;

    public float timeBetweenState = 5f;
    private float stateCountdown;

    //public float boss1Dmg;

    public GameObject electricGraphic;

    // Start is called before the first frame update
    void Start()
    {
        stateCountdown = timeBetweenState;

        boss1Lives = boss1StartLives;

        eBody = this.GetComponent<Rigidbody>();

        //find target according to PlayerManager script
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();

        //enemy will find updatePoint at start
        //updatePoint = GameObject.Find("updatePoint");

        player = GameObject.FindWithTag("Player");
        playerBody = target.GetComponent<Rigidbody>();

        //playerBody.GetComponent<PlayerController>().myBody;

        
        //InvokeRepeating("Stop", 1.0f, 4f);
        //InvokeRepeating("Continue", 3.0f, 4f);
        //InvokeRepeating("DestroyBombClones", 3.5f, 4f);

        InvokeRepeating("InstantiateBombs", 2.5f, 2.5f);

        eForce = 200f;

        lookRadius = 20;

        agent.speed = boss1Speed;

        electricGraphic.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (boss1Lives > boss1StartLives)
        {
            boss1Lives = boss1StartLives;
        }

        FaceTarget();
        //distance from enemy to player
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            //chase player
            lookRadius = Mathf.Infinity;
            agent.SetDestination(target.position);

            /*if (distance <= agent.stoppingDistance)
            {
                //face the target
                FaceTarget();
            }*/

        }

        if (boss1Lives <= 0)
        {
            Explode();
        }

        if (stateCountdown <= 0)
        {
            if (state != ElectricState.ELECTRIC)
            {
                //Start electric state
                StartCoroutine(ElectricityActive());
            }
        } else
        {
            stateCountdown -= Time.deltaTime;
        }

    }

    void Explode()
    {
        GameObject clone = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
        player.GetComponent<PlayerController>().score = player.GetComponent<PlayerController>().score + 10;
        Destroy(gameObject);
        Destroy(clone, 1f);
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

            //StartCoroutine(EneNavControl());

            if (player.GetComponent<PlayerController>().boostActivated == true)
            {
                boss1Lives = boss1Lives - PlayerPrefs.GetInt("dashDmg", 0);

            }

            boss1Lives = boss1Lives - 30;

            if (state == ElectricState.ELECTRIC)
            {
                PlayerHealth.Lives -= 40;
            } else
            {
                PlayerHealth.Lives -= 5;
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
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    //draw the look range (touch range) of the enemy in Red
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
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
        yield return new WaitForSeconds(0.3f);
        //playerBody.drag = 1000;
        //yield return new WaitForSeconds(0.1f);
        playerBody.drag = 1;

    }

    /*private IEnumerator EneNavControl()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = false;


        yield return new WaitForSeconds(1.3f);
        gameObject.GetComponent<NavMeshAgent>().enabled = true;


    }*/

    private IEnumerator EneDelayDown()
    {
        eBody.AddForce(-direction.up * 15);
        yield return new WaitForSeconds(1f);
        eBody.drag = 1;

    }

    void InstantiateBombs()
    {

        GameObject clone = (GameObject)Instantiate(bomb, transform.position + new Vector3(0, 1, 0), transform.rotation);
        GameObject clone2 = (GameObject)Instantiate(bomb, transform.position + new Vector3(0, 1, 0), transform.rotation); //Quaternion.Euler(new Vector3(0, 90, 0))
        //clone = Instantiate(bomb, transform.position + Vector3.left, transform.rotation);
        GameObject clone3 = (GameObject)Instantiate(bomb, transform.position + new Vector3(0, 1, 0), transform.rotation);
        Rigidbody BombRb = clone.GetComponent<Rigidbody>();
        Rigidbody BombRb2 = clone2.GetComponent<Rigidbody>();
        Rigidbody BombRb3 = clone3.GetComponent<Rigidbody>();
        //Physics.IgnoreCollision(clone.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        BombRb.AddForce(transform.forward * 800);
        BombRb2.AddForce((transform.position + new Vector3(-90, 0, 0)) * 3);
        BombRb3.AddForce((transform.position + new Vector3(-270, 0, 0)) * 3);

    }

    void Stop()
    {
        //eBody.drag = 1000;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;

    }
    void Continue()
    {
        //eBody.drag = 1;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
    }

    IEnumerator ElectricityActive()
    {
        state = ElectricState.ELECTRIC;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;

        electricGraphic.SetActive(true);

        yield return new WaitForSeconds(3f);

        electricGraphic.SetActive(false);

        state = ElectricState.NORMAL;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        stateCountdown = timeBetweenState;
    }

}
