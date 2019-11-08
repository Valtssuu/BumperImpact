using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explosion;

    void Start()
    {
        Invoke("SelfDestruct", 3f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject clone = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
            
            Destroy(gameObject);
            Destroy(clone, 1f);

        }
    }

    void SelfDestruct()
    {
        GameObject clone = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(clone, 1f);
    }

    
}

