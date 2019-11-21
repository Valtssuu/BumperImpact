using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
    public GameObject poisonGround;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BarrelExploded();
        }
    }

    void BarrelExploded()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        GameObject clone = Instantiate(poisonGround, transform.position, transform.rotation);
        Destroy(clone, 15f);
        Destroy(gameObject);
    }
}
