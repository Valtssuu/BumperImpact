using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItems : MonoBehaviour
{


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            
            Destroy(gameObject);
        }
    }
}
