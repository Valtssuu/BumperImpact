﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamLogo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject logoPanel;
    private bool mFaded = false;

    public float Duration = 0.4f;
    int logoPlayedInt;


    void Start()
    {

            logoPanel.SetActive(true);
            var canvGroup = GetComponent<CanvasGroup>();

            StartCoroutine(teamLogo(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

            mFaded = !mFaded;
        

    }

    IEnumerator teamLogo(CanvasGroup canvGroup, float start, float end)
    {

        yield return new WaitForSeconds(2f);
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }

        SceneManager.LoadScene("Menu");
    }

  
}
