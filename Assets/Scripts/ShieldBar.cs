using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Image shieldImg;

    public float MinS;

    public float MaxS;

    private float mCurrentValue;

    public GameObject newenemy;

    private float mCurrentPercent;

    public void Start()
    {
        
    }

    public void SetShield(float shield)
    {
        if (shield != mCurrentValue)
        {
            if (MaxS - MinS == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = shield;
                mCurrentPercent = (float)mCurrentValue / (float)(MaxS - MinS);
            }
            
            shieldImg.fillAmount = mCurrentPercent;

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
        SetShield(newenemy.GetComponent<NewEnemyAI>().shieldLives );
    }

}
