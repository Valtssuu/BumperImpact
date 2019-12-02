using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material skinCamo;
    public Material skinHippie;
    public Material skinLeopard;
    public Material[] materials;
    Material skinToChange;
    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            if (PlayerPrefs.GetInt("skinCamo", 0) == 1)
            {
                rend.material = skinCamo;
            }

            if (PlayerPrefs.GetInt("skinHippie", 0) == 1)
            {
                rend.material = skinHippie;
            }

            if (PlayerPrefs.GetInt("skinLeopard", 0) == 1)
            {
                rend.material = skinLeopard;
            }

        }
        //skinToChange = GetComponent<Renderer>().materials[0];
        //rend.skinToChange = skinCamo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
