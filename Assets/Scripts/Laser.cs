using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer laserLr;

    public int laserDamage = 30;
    public float laserRange = 50f;
    public float laserCountdown = 5f;
    public bool playerGotHit = false;
    private bool laserHit = false;
    public GameObject beamCollider;

    // Start is called before the first frame update
    void Start()
    {
        laserLr = GetComponent<LineRenderer>();
        //laserBeam.SetActive(false);
        beamCollider.SetActive(false);


    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        //laserBeam = GameObject.FindWithTag("LaserBeam");
        //laserLr.SetPosition(0, transform.position);
        laserCountdown -= Time.deltaTime;
        
        if (laserCountdown <= 2f && laserHit == false)
        {
            StartCoroutine(ActiveBeam());
            //ShootLaser();
            laserHit = true;
        }
        if (laserCountdown <= 0)
        {
            laserCountdown = 5f;
            laserHit = false;
        }

        if (!beamCollider.activeSelf)
        {
            playerGotHit = false;
        }
    }

    void ShootLaser()
    {
        playerGotHit = false;
        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.forward*laserRange);
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserRange))
        {
            if (hit.collider.tag == "Player" && playerGotHit == false)
            {
                //StartCoroutine(LineHit(hit));
                PlayerHealth.Lives -= 30;
                
                playerGotHit = true;
                return;
            }
            
            
        }
        //StartCoroutine(LineShow());
        
    }

    

    IEnumerator ActiveBeam()
    {
        
        beamCollider.SetActive(true);
        yield return new WaitForSeconds(2f);
        beamCollider.SetActive(false);
    }

    IEnumerator LineShow()
    {
        laserLr.SetPositions(new Vector3[] { transform.position, transform.position + (transform.forward * laserRange) });
        yield return new WaitForSeconds(0.3f);
        laserLr.SetPositions(new Vector3[] { transform.position, transform.position });
    }

    IEnumerator LineHit(RaycastHit hit)
    {
        laserLr.SetPositions(new Vector3[] { transform.position, hit.point });
        yield return new WaitForSeconds(0.3f);
        laserLr.SetPositions(new Vector3[] { transform.position, transform.position });
    }
}
