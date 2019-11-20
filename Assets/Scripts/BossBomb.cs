using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBomb : MonoBehaviour
{
    public GameObject bomb;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateBombs", 2.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateBombs()
    {

        GameObject clone = (GameObject)Instantiate(bomb, transform.position, transform.rotation);
        Rigidbody BombRb = clone.GetComponent<Rigidbody>();
        BombRb.AddForce(transform.forward * 800);
        Physics.IgnoreCollision(clone.GetComponent<Collider>(), boss.gameObject.GetComponent<Collider>());
        /*if (boss.GetComponent<BossW1AI>().boss1PercentLive <= 50f)
        {

        }
        GameObject clone2 = (GameObject)Instantiate(bomb, canonPoint2.transform.position, transform.rotation);
        Physics.IgnoreCollision(clone2.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        GameObject clone3 = (GameObject)Instantiate(bomb, canonPoint3.transform.position, transform.rotation);
        Physics.IgnoreCollision(clone3.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        Rigidbody BombRb2 = clone2.GetComponent<Rigidbody>();
        Rigidbody BombRb3 = clone3.GetComponent<Rigidbody>();

        BombRb2.AddForce(transform.forward * 800);
        //BombRb2.velocity = transform.forward * 30;
        BombRb3.AddForce(transform.forward * 800);*/
    }
}
