using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform target;

    public float hideDistance = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = target.position - transform.position;

        if (dir.magnitude < hideDistance)
        {
            SetChildrenActive(false); 
        }

        else
        {
            foreach (Transform child in transform)
            {
                SetChildrenActive(true);

                var angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }
        }

    }

    void SetChildrenActive (bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
