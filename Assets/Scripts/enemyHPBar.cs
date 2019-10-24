using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHPBar : MonoBehaviour
{
    public Image imgHPBarE;

    public int MinE;

    public int MaxE;

    public GameObject enemy;

    private int mCurrentValueE;

    private float mCurrentPercentE;


    public Transform WhereToLook;

    private void Start()
    {
        WhereToLook = GameObject.FindWithTag("WhereToLook").GetComponent<Transform>();
    }
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
                mCurrentPercentE = (int)mCurrentValueE * 100 / (int)(MaxE - MinE) ;

            }
            imgHPBarE.fillAmount = mCurrentPercentE / 100;


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
        gameObject.transform.LookAt(WhereToLook);
    }

}
