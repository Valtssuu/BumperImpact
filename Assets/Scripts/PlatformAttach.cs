using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    [SerializeField] private Animator PlatformController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            
            player.transform.SetParent(this.transform, true);

            PlatformController.SetBool("playPlatform", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
            PlatformController.SetBool("playPlatform", false);
        }
    }
}
