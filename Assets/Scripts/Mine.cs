using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

    public float delay = 2f;
    float countdown;

    bool hasExploded = false;

    public float exRadius = 15f;
    public float exPower = 2000f;

    //private Vector3 explosionPos;

    public GameObject explosionEffect;

    //GameObject enemyLivesRef;

    public Rigidbody playerBody;
    
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
    void Update()
    {
        /*countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            MineExplosion();
            hasExploded = true;
        }*/
        
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2"))
        {
            if (!hasExploded)
            {
                //Call AddExploForce function
                MineExplosion();
                hasExploded = true;
            }
            

            
        }
    }

    void MineExplosion()
    {
        //Instantiate the explosion prefab
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] exColliers = Physics.OverlapSphere(transform.position, exRadius);
        
        foreach (Collider hit in exColliers)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            

            if (rb != null && rb != playerBody)
            {
                rb.AddExplosionForce(exPower, transform.position, exRadius);

                
                //enemyInRange.GetComponent<EnemyAI>().enemyLives -= 80;
                //StartCoroutine(DelayDestroy(hit));
                hit.GetComponent<EnemyAI>().enemyLives -= 80;
                hit.GetComponent<NewEnemyAI>().enemyLives -= 80;

                rb.drag = 5;
                
                
                Destroy(gameObject);
            }
        }
        
    }

    /*IEnumerator DelayDestroy(Collider hit)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(hit.gameObject);
    }*/
    
}
