using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer laserLr;

    public int laserDamage = 30;
    public float laserRange = 100f;
    public float laserCountdown = 3f;
    private bool playerGotHit = false;
    // Start is called before the first frame update
    void Start()
    {
        laserLr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //laserLr.SetPosition(0, transform.position);
        laserCountdown -= Time.deltaTime;
        if (laserCountdown <= 0)
        {
            ShootLaser();
            laserCountdown = 3f;
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
                StartCoroutine(LineHit(hit));
                PlayerHealth.Lives -= 30;
                
                playerGotHit = true;
                return;
            }
            
            
        }
        StartCoroutine(LineShow());
    }

    IEnumerator LineShow()
    {
        laserLr.SetPositions(new Vector3[] { transform.position, transform.position + (transform.forward * laserRange) });
        yield return new WaitForSeconds(0.2f);
        laserLr.SetPositions(new Vector3[] { transform.position, transform.position });
    }

    IEnumerator LineHit(RaycastHit hit)
    {
        laserLr.SetPositions(new Vector3[] { transform.position, hit.point });
        yield return new WaitForSeconds(0.2f);
        laserLr.SetPositions(new Vector3[] { transform.position, transform.position });
    }
}
