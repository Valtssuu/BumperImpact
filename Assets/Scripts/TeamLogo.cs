using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamLogo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject logoPanel;
    private bool mFaded = false;

    public float Duration = 0.4f;
    int logoPlayedInt;


    void Start()
    {

        logoPlayedInt = PlayerPrefs.GetInt("logoPlayed", 0);

        if(logoPlayedInt == 1)
        {
            logoPanel.SetActive(false);
        }
        if(logoPlayedInt == 0)
        {
            logoPanel.SetActive(true);
            var canvGroup = GetComponent<CanvasGroup>();

            StartCoroutine(teamLogo(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

            mFaded = !mFaded;
            PlayerPrefs.SetInt("logoPlayed", 1);
        }
        
        

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
        logoPanel.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("logoPlayed", 0);
    }
}
