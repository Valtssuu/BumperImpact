using UnityEngine;
using System.Collections;

public class CamerasDefaultPlace : MonoBehaviour
{
    public Transform target; //This will be your citizen
    public float distance;
    //tilt is x, talt is y and tult is z 
    public float tilt, talt, tult;

    void Update()
    {


        transform.rotation = Quaternion.Euler(tilt, tult, talt);
        if (!target)
        {
            var go = GameObject.FindWithTag("Player");
            // Check we found an object with the player tag
            if (go)
                // Set the target to the object we found
                target = go.transform;
        }

        if (target)
        {
            transform.position = new Vector3(target.position.x - distance, target.position.y , target.position.z);
            //transform.rotation = Quaternion.Euler(tilt, 0, 0);
        }


    }
}