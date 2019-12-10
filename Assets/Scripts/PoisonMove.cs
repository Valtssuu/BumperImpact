using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonMove : MonoBehaviour
{
    public AudioClip barrelExplosionClip;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(barrelExplosionClip, transform.position);
        Invoke("Move", 14f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        transform.position = new Vector3(-10000, -10000, -10000);
    }
}
