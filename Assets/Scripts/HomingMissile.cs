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
    

    

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        target = player.GetComponent<PlayerController>().target;
        hasExploded = false;
        Invoke("SelfDestruct", 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = target.position - rb.position;
        direction.Normalize();

        Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
        
        rb.angularVelocity = rotationAmount * rotationForce;
        rb.velocity = transform.forward * force;

        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2"))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            if (!hasExploded)
            {
                //Call AddExploForce function
                Destroy(other.gameObject);
                Destroy(gameObject);

                hasExploded = true;
            }
            

            
        }

        if (other.gameObject.CompareTag("Boss1"))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            if (!hasExploded)
            {
                other.gameObject.GetComponent<BossW1AI>().boss1Lives -= 100;

                hasExploded = true;
            }
        }
    }

    void SelfDestruct ()
    {
        Destroy(gameObject);
    }

    
}
