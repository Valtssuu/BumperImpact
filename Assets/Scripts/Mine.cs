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

    public AudioClip explosionClip;
    
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
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy2") || collision.gameObject.CompareTag("EnemyShield"))
        {
            if (!hasExploded)
            {
                //Call AddExploForce function
                AudioSource.PlayClipAtPoint(explosionClip, transform.position);
                MineExplosion();
                
                
                hasExploded = true;
                Destroy(gameObject);
            }

        }

        /*if (collision.gameObject.CompareTag("Enemy2") || collision.gameObject.CompareTag("EnemyShield"))
        {
            if (!hasExploded)
            {
                MineExplosion();
                
                
                hasExploded = true;
                Destroy(gameObject);
            }
            
        }*/

        if (collision.gameObject.CompareTag("Boss1"))
        {
            if (!hasExploded)
            {
                GameObject exClone = Instantiate(explosionEffect, transform.position, transform.rotation);
                Destroy(exClone, 1f);
                AudioSource.PlayClipAtPoint(explosionClip, transform.position);
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

        //Vector3 explosionPos = transform.position;

        Collider[] exColliers = Physics.OverlapSphere(transform.position, exRadius);
        
        
        foreach (Collider hit in exColliers)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            //Rigidbody mineRb = gameObject.GetComponent<Rigidbody>();

            if (rb != null && rb != playerBody)
            {
                rb.AddExplosionForce(exPower, transform.position, exRadius, 1f, ForceMode.Impulse);
                rb.drag = 1;
                if (rb.gameObject.CompareTag("Enemy"))
                {
                    hit.gameObject.GetComponent<EnemyAI>().enemyLives -= 80;

                }
                if (rb.gameObject.CompareTag("Enemy2"))
                {
                    rb.AddForce(transform.position * 200);
                    rb.drag = 1;
                    hit.gameObject.GetComponent<NewEnemyAI>().enemyLives -= 80;
                }
            }
            

            
        }

        //Destroy(gameObject);


    }

    IEnumerator DelayDestroy(Collider hit)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(hit.gameObject);
    }
    
}
