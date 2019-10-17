using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    public Image imgDashBar;
    public Image imgDashBarOver50;
    public Text TxtDash;

    public float Min;

    public float Max;

    public GameObject player;

    private float mCurrentValue;

    private float mCurrentPercent;
    
    

    public void SetDash(float dash)
    {
        if(dash != mCurrentValue)
        {
            if(Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = dash;
                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
            }
            

            imgDashBar.fillAmount = mCurrentPercent;
            imgDashBarOver50.fillAmount = mCurrentPercent;

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
        SetDash(player.GetComponent<PlayerController>().dashmeter * 10);
    }

}
