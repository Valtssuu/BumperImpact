using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text Timerlabel;
    private float time;
    private float startTime;

    bool keepTiming;
    float timer;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {

        if (GameObject.FindWithTag("Enemy1A3") == null)
        {
            Debug.Log("Timer stopped at " + TimeToString(StopTimer()));
        }

        if (keepTiming)
        {
            UpdateTime();
        }
    }

    void UpdateTime()
    {
        timer = Time.time - startTime;
        Timerlabel.text = TimeToString(timer);
    }

    float StopTimer()
    {
        keepTiming = false;
        return timer;
    }

    void ResumeTimer()
    {
        keepTiming = true;
        startTime = Time.time - timer;
    }

    void StartTimer()
    {
        keepTiming = true;
        startTime = Time.time;
    }

    string TimeToString(float t)
    {
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        return minutes + ":" + seconds;
    }
}