using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    //public int Inventory;
    // Start is called before the first frame update
    public AudioClip healClip;
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(healClip, transform.position);
            Destroy(gameObject);

            PlayerHealth.Lives += 20;

            collision.gameObject.GetComponent<PlayerController>().HealthBox();
        }
        
    }
}
