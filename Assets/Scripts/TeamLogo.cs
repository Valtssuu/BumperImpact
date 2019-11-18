using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamLogo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject logoPanel;
    private bool mFaded = false;

    public float Duration = 0.4f;


    void Start()
    {
        logoPanel.SetActive(true);
        var canvGroup = GetComponent<CanvasGroup>();

        //logoPanel.SetActive(true);
        StartCoroutine(teamLogo(canvGroup,canvGroup.alpha, mFaded ? 1 : 0));

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
        yield return new WaitForSeconds(1.8f);
        logoPanel.SetActive(false);
        //yield return new WaitForSeconds(3f);
        //logoPanel.SetActive(false);
    }
}
