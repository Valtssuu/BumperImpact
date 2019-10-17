using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image imgHPBar;

    public float Minh;

    public float Maxh;

    public GameObject player;

    private float mCurrentValue;

    private float mCurrentPercent;



    public void SetHealth(float health)
    {
        if (health != mCurrentValue)
        {
            if (Maxh - Minh == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = health;
                mCurrentPercent = (float)mCurrentValue / (float)(Maxh - Minh);
            }
            
            imgHPBar.fillAmount = mCurrentPercent;

        }
    }


    public float CurrentPercent
    {
        get { return mCurrentPercent; }
    }

    public float CurrentValue
    {
        get { return mCurrentValue; }
    }


    void Update()
    {
        SetHealth(PlayerHealth.Lives);
    }

}
