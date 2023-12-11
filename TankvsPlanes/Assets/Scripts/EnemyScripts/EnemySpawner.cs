using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject[] enemies; 
    public float timeBetweenSpawns = 1f; 
}

public class EnemySpawner : MonoBehaviour
{
    public List<Wave> waves = new List<Wave>();  
    public float timeBetweenWaves = 5f; 
    public float spawnRadius = 2f; 
    private Transform spawnPoint; 

    private void Start()
    {
        spawnPoint = transform;
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {

        for (int waveIndex = 0; waveIndex < waves.Count; waveIndex++)
        {
            
            yield return new WaitForSeconds(timeBetweenWaves);

            Wave currentWaveSettings = waves[waveIndex];


            for (int enemyIndex = 0; enemyIndex < currentWaveSettings.enemies.Length; enemyIndex++)
            {
                
                Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
                Vector3 spawnPosition = spawnPoint.position + new Vector3(randomOffset.x, randomOffset.y, 0f);


                GameObject enemyPrefab = currentWaveSettings.enemies[enemyIndex];

              
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

              
                yield return new WaitForSeconds(currentWaveSettings.timeBetweenSpawns);
            }
        }
        
    }
}