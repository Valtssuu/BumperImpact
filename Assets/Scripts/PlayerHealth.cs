using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float Lives;
    public int startLives = 100;

    
    // Start is called before the first frame update
    void Start()
    {
        Lives = startLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (Lives < startLives)
        {
            Lives = Lives + Time.deltaTime/2;
        }

        if (Lives > startLives)
        {
            Lives = startLives;
        }
    }
    
}
