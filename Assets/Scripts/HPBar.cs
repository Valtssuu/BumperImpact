using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    Image imgHPBar;
    GameObject HPBarPlayer;
    public float Minh;

    public float Maxh;

    GameObject player;

    private float mCurrentValue;

    private float mCurrentPercent;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        HPBarPlayer = GameObject.FindWithTag("HPBarPlayer");
        imgHPBar = HPBarPlayer.GetComponent<Image>();
    }

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
