using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisLocation : MonoBehaviour
{

    public GameObject joystick;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = joystick.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
