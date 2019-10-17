using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    public Transform healthBox;
    private float boxCountdown;
    public float timeBetweenBoxes = 10f;
    private float searchCountdown = 1f;

    private Transform clone;

    private SpawnState state = SpawnState.COUNTING;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCountdown = timeBetweenBoxes;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //check if there's box
            if (!BoxesIsUp())
            {
                //spawn box
                BoxCollected();
            }
            else
            {
                return;
            }
        }

        if (boxCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Start spawning
                StartCoroutine(SpawnBox());
            }
        }
        else
        {
            boxCountdown -= Time.deltaTime;
        }
    }

    void BoxCollected()
    {
        state = SpawnState.COUNTING;
        boxCountdown = timeBetweenBoxes;
    }

    bool BoxesIsUp()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (clone == null)
            {
                return false;
            }
        }
        
        return true;
    }

    IEnumerator SpawnBox()
    {
        state = SpawnState.SPAWNING;
        //Spawn
        
        clone = (Transform)Instantiate(healthBox, transform.position, transform.rotation);
        yield return new WaitForSeconds(2f);
        
        state = SpawnState.WAITING;
        
        //yield break;
    }

    
}
