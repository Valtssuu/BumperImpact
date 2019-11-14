using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

    //public float delay = 2f;
    //float countdown;

    bool hasExploded = false;

    public float exRadius = 20f;
    public float exPower = 50f;

    //private Vector3 explosionPos;

    public GameObject explosionEffect;

    //GameObject enemyLivesRef;

    public Rigidbody playerBody;

    public GameObject mine;

    public float enemy1Live;

    public float bigEnemyLive;
    
    void Start()
    {
        //countdown = delay;
        
        //geteBody = GameObject.GetComponent<>

        //enemyLivesRef = GameObject.FindWithTag("Enemy1");

        //get player's rigidbody
        playerBody = PlayerManager.instance.player.transform.GetComponent<Rigidbody>();
        
        

        hasExploded = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            MineExplosion();
            hasExploded = true;
        }*/
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy2"))
        {
            if (!hasExploded)
            {
                //Call AddExploForce function
                MineExplosion();
                hasExploded = true;

            }

        }

        if (collision.gameObject.CompareTag("Boss1"))
        {
            if (!hasExploded)
            {
                GameObject exClone = Instantiate(explosionEffect, transform.position, transform.rotation);
                Destroy(exClone, 1f);
                collision.gameObject.GetComponent<BossW1AI>().boss1Lives -= 70f;
                Destroy(gameObject);
            }
        }
    }

    void MineExplosion()
    {
        //Instantiate the explosion prefab
        GameObject exClone = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(exClone, 1f);

        Vector3 explosionPos = mine.transform.position;

        Collider[] exColliers = Physics.OverlapSphere(explosionPos, exRadius);
        
        
        foreach (Collider hit in exColliers)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            Rigidbody mineRb = gameObject.GetComponent<Rigidbody>();

            //enemy1Live = hit.gameObject.GetComponent<EnemyAI>().enemyLives;
            //bigEnemyLive = hit.GetComponent<NewEnemyAI>().enemyLives;

            if (rb != null && rb != playerBody && rb != mineRb)
            {
                rb.AddExplosionForce(exPower, explosionPos, exRadius, 1f, ForceMode.Impulse);

                //enemy1Live -= 80;
                //bigEnemyLive -= 80;
                
                //StartCoroutine(DelayDestroy(hit));
                //hit.GetComponent<EnemyAI>().enemyLives -= 80;
                //hit.GetComponent<NewEnemyAI>().enemyLives -= 80;

                rb.drag = 1;

                Destroy(rb.gameObject);

            }

            
        }

        Destroy(gameObject);


    }

    /*IEnumerator DelayDestroy(Collider hit)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(hit.gameObject);
    }*/
    
}
