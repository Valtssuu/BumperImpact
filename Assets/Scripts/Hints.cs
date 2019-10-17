using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public GameObject hint1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            hint1.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
