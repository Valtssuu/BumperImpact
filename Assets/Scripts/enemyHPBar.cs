using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHPBar : MonoBehaviour
{
    public Image imgHPBar;

    public int MinE;

    public int MaxE;

    public GameObject enemy;

    private int mCurrentValueE;

    private float mCurrentPercentE;



    public void SetHealth(int health)
    {
        if (health != mCurrentValueE)
        {
            if (MaxE - MinE == 0)
            {
                mCurrentValueE = 0;
                mCurrentPercentE = 0;
            }
            else
            {
                mCurrentValueE = health;
                mCurrentPercentE = (int)mCurrentValueE / (int)(MaxE - MinE) * 100;
            }

            imgHPBar.fillAmount = mCurrentPercentE;

        }
    }

    
    public float CurrentPercentE
    {
        get { return mCurrentPercentE; }
    }

    public int CurrentValueE
    {
        get { return mCurrentValueE; }
    }


    void Update()
    {
        SetHealth(enemy.GetComponent<EnemyAI>().enemyLives);
        
    }

}
