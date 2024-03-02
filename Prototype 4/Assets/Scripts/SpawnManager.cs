using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9f;
    public int enemiesAlive;
    public int waveNumber = 1;

    void Start()
    {
        // spawn first enemy
        spawnEnemyWave(waveNumber);

        // spawn first powerup
        Instantiate(powerupPrefab, generateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void Update()
    {
        // check for enemies alive
        enemiesAlive = FindObjectsOfType<Enemy>().Length;
        // if there are no enemies, spawn new wave
        if (enemiesAlive == 0)
        {
            waveNumber++;
            spawnEnemyWave(waveNumber);
            Instantiate(enemyPrefab, generateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 generateSpawnPosition()
    {
        // generate random x and z for spawn position
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        // return new spawn position
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    private void spawnEnemyWave(int enemiesToSpawn)
    {
        // spawn enemiesToSpawn amount of enemies 
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, generateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
