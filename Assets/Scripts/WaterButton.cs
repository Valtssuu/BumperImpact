using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterButton : MonoBehaviour
{
    public float range = 2f;
    public bool touchedButton = false;

    private bool touchOnce = false;

    public ParticleSystem waterLine;

    

    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;

        waterLine = GameObject.FindWithTag("WaterLine").GetComponent<ParticleSystem>();
        
        touchedButton = false;
        touchOnce = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance > range)
        {
            touchOnce = false;
        }
        if (distance <= range)
        {
            
            //Debug.Log("In");
            if (touchedButton == false && touchOnce == false)
            {
                Debug.Log("Turn it on");
                waterLine.Play();
                touchedButton = true;
                touchOnce = true;
                
                
            }
            if (touchedButton == true && touchOnce == false)
            {
                Debug.Log("Turn it off");
                waterLine.Stop();
                touchedButton = false;
                touchOnce = true;

            }

        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
