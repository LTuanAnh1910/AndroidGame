using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;

    public float timeBetweenWaves;
    private float countdown = 10f;
    private int waveIndex = 0;


    private void Start()
    {
        
    }

    int count = 1;
    void Update()
    {
        
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnEnemy());
            countdown = timeBetweenWaves * count;
            count++;
            if(countdown >= 50f)
            {
                countdown = 10f;
                count = 1;
            }
            Player.Wave++;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    private IEnumerator SpawnEnemy()
    {
        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            int rand = UnityEngine.Random.Range(0, wave.enemy.Length);
            GameObject bossToSpawn = wave.enemy[rand];
            
            Instantiate(bossToSpawn, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(wave.rate);
        }
        waveIndex++;

    }
}
