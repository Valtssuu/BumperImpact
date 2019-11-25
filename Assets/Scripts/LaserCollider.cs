using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollider : MonoBehaviour
{
    public Laser ls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ls.playerGotHit == false)
        {
            PlayerHealth.Lives -= 30;

            ls.playerGotHit = true;
        }
    }
}
