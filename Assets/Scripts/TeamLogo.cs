using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamLogo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject logoPanel;
    void Start()
    {
        logoPanel.SetActive(true);
        StartCoroutine("teamLogo");
    }

    IEnumerator teamLogo()
    {
        yield return new WaitForSeconds(3f);
        logoPanel.SetActive(false);
    }
}
