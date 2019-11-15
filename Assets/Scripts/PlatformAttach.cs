using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player || other.gameObject.tag == "Enemy1")
        {
            
            player.transform.SetParent(this.transform, true);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player || other.gameObject.tag == "Enemy1")
        {
            player.transform.parent = null;
        }


    }
}
