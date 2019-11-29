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
        if (other.gameObject == player || other.gameObject.tag == "Enemy")
        {

            player.transform.SetParent(this.transform, true);
            other.transform.SetParent(this.transform, true);

        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player || other.gameObject.tag == "Enemy")
        {
            player.transform.parent = null;
            other.transform.parent = null;
        }
    }
}
