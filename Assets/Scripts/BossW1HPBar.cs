using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossW1HPBar : MonoBehaviour
{
    public Image imgHPBarB;

    public float MinB;

    public float MaxB;

    public GameObject boss;

    private float mCurrentValueE;

    private float mCurrentPercentE;



    public void SetHealth(float health)
    {
        if (health != mCurrentValueE)
        {
            if (MaxB - MinB == 0)
            {
                mCurrentValueE = 0;
                mCurrentPercentE = 0;
            }
            else
            {
                mCurrentValueE = health;
                mCurrentPercentE = (float)mCurrentValueE * 100 / (float)(MaxB - MinB) ;

            }
            
            imgHPBarB.fillAmount = mCurrentPercentE / 100;

            Debug.Log(imgHPBarB.fillAmount);
            Debug.Log(health);

        }
    }

    
    public float CurrentPercentE
    {
        get { return mCurrentPercentE; }
    }

    public float CurrentValueE
    {
        get { return mCurrentValueE; }
    }


    void Update()
    {
        SetHealth(boss.GetComponent<BossW1AI>().boss1Lives);
    }

}
