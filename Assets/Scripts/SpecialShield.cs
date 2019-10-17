using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialShield : MonoBehaviour
{

    public GameObject shield;
    public float shieldLives = 75;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            shield.SetActive(true);
            Destroy(gameObject);
        }
    }
}
