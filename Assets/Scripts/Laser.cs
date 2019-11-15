using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer laserLr;

    public int laserDamage = 30;
    public float laserRange = 50f;
    public float laserCountdown = 3.6f;
    private bool playerGotHit = false;
    private bool laserHit = false;
    

    // Start is called before the first frame update
    void Start()
    {
        laserLr = GetComponent<LineRenderer>();
        //laserBeam.SetActive(false);
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        //laserBeam = GameObject.FindWithTag("LaserBeam");
        //laserLr.SetPosition(0, transform.position);
        laserCountdown -= Time.deltaTime;
        
        if (laserCountdown <= 1f && laserHit == false)
        {
            ShootLaser();
            laserHit = true;
        }
        if (laserCountdown <= 0)
        {
            laserCountdown = 3.6f;
            laserHit = false;
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
