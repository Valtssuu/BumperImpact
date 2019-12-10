using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float force;
    [SerializeField] private float rotationForce;
    private Rigidbody rb;

    public GameObject player;

    public GameObject explosionEffect;

    bool hasExploded = false;

    public AudioClip missileClip;
    public AudioClip impactClip;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        target = player.GetComponent<PlayerController>().target;
        hasExploded = false;
        Invoke("SelfDestruct", 3);
        AudioSource.PlayClipAtPoint(missileClip, transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("hasRocket", 0) == 1)
        {
            Vector3 direction = target.position - rb.position;
            direction.Normalize();

            Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);

            rb.angularVelocity = rotationAmount * rotationForce;
            rb.velocity = transform.forward * force;
        } else
        {
            rb.velocity = transform.forward * force;
        }
        
        
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2"))
        {
            if (!hasExploded)
            {
                //Call AddExploForce function
                Instantiate(explosionEffect, transform.position, transform.rotation);
                AudioSource.PlayClipAtPoint(impactClip, transform.position);
                if (other.gameObject.CompareTag("Enemy"))
                {
                    other.gameObject.GetComponent<EnemyAI>().Explode();
                }
                if (other.gameObject.CompareTag("Enemy2"))
                {
                    other.gameObject.GetComponent<NewEnemyAI>().Explode();
                }

                Destroy(gameObject);

                hasExploded = true;
            }
            

            
        }

        if (other.gameObject.CompareTag("Boss1"))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(impactClip, transform.position);
            if (!hasExploded)
            {
                other.gameObject.GetComponent<BossW1AI>().boss1Lives -= 50;
                Destroy(gameObject);
                hasExploded = true;
            }
        }
    }

    void SelfDestruct ()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    
}
