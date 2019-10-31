using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPistol : MonoBehaviour
{
    private LineRenderer waterLr;
    public float waterRange = 100f;
    public bool waterOn = true;
    public GameObject waterLine;
    public GameObject clone;
    private bool oneWaterLine = false;
    public WaterButton script;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.FindWithTag("WaterButton").GetComponent<WaterButton>();
        //waterLr = GetComponent<LineRenderer>();
        oneWaterLine = false;
        waterOn = true;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (waterOn == true && oneWaterLine == false)
        {
            //GameObject clone = GameObject.Instantiate(waterLine, transform.position, transform.rotation);
            oneWaterLine = true;
            if (script.touchedButton == true)
            {
                //Destroy(clone);
                waterOn = false;
                oneWaterLine = false;
            }

        }

        if (script.touchedButton == false)
        {
            waterOn = true;
            
        }

    }

}
