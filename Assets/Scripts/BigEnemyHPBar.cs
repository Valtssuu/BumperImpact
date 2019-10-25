using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigEnemyHPBar : MonoBehaviour
{
    public Image imgHPBarE;

    public int MinBE;

    public int MaxBE;

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
            if (MaxBE - MinBE == 0)
            {
                mCurrentValueE = 0;
                mCurrentPercentE = 0;
            }
            else
            {
                mCurrentValueE = health;
                mCurrentPercentE = (int)mCurrentValueE * 100 / (int)(MaxBE - MinBE);

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
        SetHealth(enemy.GetComponent<NewEnemyAI>().enemyLives);
        gameObject.transform.LookAt(WhereToLook);
    }

}
