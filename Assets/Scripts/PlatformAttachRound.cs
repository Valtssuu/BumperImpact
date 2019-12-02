using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttachRound : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
   
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject == player )
        {

            player.transform.SetParent(this.transform, true);

        }

        if(other.gameObject.tag == "ExplodingBarrel")
        {
            other.transform.SetParent(this.transform, true);

        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player )
        {
            player.transform.parent = null;
        }
        if (other.gameObject.tag == "ExplodingBarrel")
        {
            other.transform.parent = null;

        }
    }
}
