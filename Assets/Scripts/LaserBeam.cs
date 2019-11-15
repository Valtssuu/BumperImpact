using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{

    public GameObject endPoint;
    public float laserCountdown = 3.6f;
    public ParticleSystem laserBeam;

    //public GameObject laserBeam;
    private bool laserShown = false;

    Animator laserAnimator;
    // Start is called before the first frame update
    void Start()
    {
        laserCountdown = 3.6f;
        laserShown = false;
        laserAnimator = GetComponent<Animator>();
        //laserAnimator.StopPlayback();
        //laserBeam.Stop();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        laserCountdown -= Time.deltaTime;
        endPoint = GameObject.FindWithTag("LaserEnd");

        if (laserCountdown <= 3.6f && laserShown == false)
        {
            laserShown = true;
            StartCoroutine(LaserShow());
            
            
        }

        if (laserCountdown <=0)
        {
            laserCountdown = 3.6f;
            laserShown = false;
        }
    }

    IEnumerator LaserShow()
    {
        laserAnimator.Play("laser_ON");
        yield return new WaitForSeconds(2.6f);
        laserBeam.Play();
        yield return new WaitForSeconds(0.3f);
        laserBeam.Stop();
        laserAnimator.StopPlayback();
    }
}
