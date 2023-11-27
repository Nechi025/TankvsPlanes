using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject[] enemies; // Lista de prefabs de enemigos
    public float timeBetweenSpawns = 1f; // Tiempo entre spawns
}

public class EnemySpawner : MonoBehaviour
{
    public List<Wave> waves = new List<Wave>(); // List de Waves 
    public float timeBetweenWaves = 5f; // Tiempo entre Waves
    public float spawnRadius = 2f; // Radio en el que pueden spawnear los enemigos

    //private int currentWave = 0; // Wave actual sin uso todavia

    private Transform spawnPoint; // Punto de aparicion de enemigos

    private void Start()
    {
        spawnPoint = transform;

        // Se empieza las oleadas
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {

        for (int waveIndex = 0; waveIndex < waves.Count; waveIndex++)
        {
            //Se espera el tiempo de ronda
            yield return new WaitForSeconds(timeBetweenWaves);

            Wave currentWaveSettings = waves[waveIndex];


            for (int enemyIndex = 0; enemyIndex < currentWaveSettings.enemies.Length; enemyIndex++)
            {
                // Posicion dentro del radio de spawn
                Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
                Vector3 spawnPosition = spawnPoint.position + new Vector3(randomOffset.x, randomOffset.y, 0f);

                // Siguiente Prefab a spawnear
                GameObject enemyPrefab = currentWaveSettings.enemies[enemyIndex];

                // Spawneo
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                // Esperar tiempo entre Spawns
                yield return new WaitForSeconds(currentWaveSettings.timeBetweenSpawns);
            }
        }
        yield return new WaitForSeconds(8);

        GameManager.instance.YouWin();
    }
}