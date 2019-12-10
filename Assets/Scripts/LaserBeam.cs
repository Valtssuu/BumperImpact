using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{

    public GameObject endPoint;
    public float laserCountdown = 5f;
    public ParticleSystem laserBeam;

    //public GameObject laserBeam;
    private bool laserShown = false;

    Animator laserAnimator;

    public AudioClip chargingClip;
    public AudioClip firingClip;
    // Start is called before the first frame update
    void Start()
    {
        laserCountdown = 5f;
        laserShown = false;
        laserAnimator = GetComponent<Animator>();
        //laserAnimator.StopPlayback();
        laserBeam.Stop();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        laserCountdown -= Time.deltaTime;
        endPoint = GameObject.FindWithTag("LaserEnd");

        if (laserCountdown <= 4.6f && laserShown == false)
        {
            laserShown = true;
            StartCoroutine(LaserShow());
            
            
        }

        if (laserCountdown <=0)
        {
            laserCountdown = 5f;
            laserShown = false;
        }
    }

    IEnumerator LaserShow()
    {
        laserAnimator.Play("laser_ON");
        AudioSource.PlayClipAtPoint(chargingClip, transform.position);
        yield return new WaitForSeconds(2.6f);
        laserBeam.Play();
        AudioSource.PlayClipAtPoint(firingClip, transform.position);
        yield return new WaitForSeconds(2f);
        laserBeam.Stop();
        laserAnimator.StopPlayback();
    }
}
