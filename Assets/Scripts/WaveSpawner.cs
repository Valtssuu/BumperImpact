using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countdown = 2f;

    private int waveIndex = 0;

    void Start()
    {
        
    }



    
    void Update()
    {
        if (countdown <= 0f)
        {
            if (waveIndex >= 3)
            {
                StopCoroutine(SpawnWave());
            }

            else
            {
                StartCoroutine(SpawnWave());
                countdown = 2f;
            }
            
            
        }

        countdown -= Time.deltaTime;

        
    }

    IEnumerator SpawnWave ()
    {
        Debug.Log("Wave spawning!!");

        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2f);
        }

        
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
