using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float slowdownFactor = 0.02f;
    public float slowdownLength = 1f;

    void FixedUpdate()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        Time.fixedDeltaTime = Time.timeScale * .02f;

    }

    public void DoSlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    
}
