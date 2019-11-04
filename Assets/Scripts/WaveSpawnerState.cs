﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerState : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        //public Transform enemy;
        //public List<Transform> enemies = new List<Transform>();
        public int count;

        public List<Transform> enemies;
        //public float rate;
        //public Transform enemy = enemies[Random.Range(0, enemies.Count)];

        /*void Start()
        {
            enemy = enemies[Random.Range(0, enemies.Count)];
        }*/
        
        
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    private bool looping = false;

    private bool toomanySpecial = false;

    public GameObject bigEnemy;
    
    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawnpoint reference!");
        }
        
        waveCountdown = timeBetweenWaves;

        looping = false;
        toomanySpecial = false;


    }

    
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy2").Length > 0)
        {
            RemoveSpecialEnemy(waves[nextWave]);
        }

        if (GameObject.FindGameObjectsWithTag("Enemy2").Length <= 0 && toomanySpecial == true)
        {
            AddSpecialEnemy(waves[nextWave]);
        }

        if (state == SpawnState.WAITING)
        {
            //check if enemy is alive
            if (!EnemyIsAlive())
            {
                //begin new round
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Start spawning
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        
        
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            //looping back last wave
            nextWave = waves.Length - 1;
            looping = true;
        }
        else
        {
            nextWave++;
        }

        


    }

    void RemoveSpecialEnemy(Wave _wave)
    {
        toomanySpecial = true;
        _wave.enemies.Remove(bigEnemy.transform);
    }

    void AddSpecialEnemy(Wave _wave)
    {
        _wave.enemies.Add(bigEnemy.transform);
        toomanySpecial = false;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null && GameObject.FindGameObjectWithTag("Enemy2") == null)
            {
                return false;
            }
        }
        
        

        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        state = SpawnState.SPAWNING;
        
        //Spawn
        if (nextWave + 1 > waves.Length - 1 && looping == true)
        {
            //Add 1 more enemy
            _wave.count = _wave.count + 1;
            

        }
        for (int i = 0; i < _wave.count; i++)
        {
            int enemy = Random.Range(0, _wave.enemies.Count);
            SpawnEnemy(_wave.enemies[enemy]);
            yield return new WaitForSeconds(2f);
        }

        state = SpawnState.WAITING;
        
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        
        
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        //Spawn enemy
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
