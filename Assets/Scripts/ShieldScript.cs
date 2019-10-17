using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{

    public int shieldLives;

    // Update is called once per frame


    private void Start()
    {
        shieldLives = 90;
    }

    void Update()
    {
        if(shieldLives == 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shieldLives -= 30;
            if(shieldLives == 0)
            {
                Destroy(gameObject);
                Debug.Log("HAHA");
            }
           
        }
        
        
    }
}
