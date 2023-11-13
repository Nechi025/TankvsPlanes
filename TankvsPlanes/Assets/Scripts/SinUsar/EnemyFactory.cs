//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyFactory : MonoBehaviour
//{
//    public GameObject enemyPrefab;

//    public GameObject CreateEnemy(Vector2 position, int maxHealth, float speed, float lifetime, int bombAmount, float bombDelay, float bombCooldown)
//    {
//        // Create an instance of the enemy prefab
//        GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);

//        // Access the Enemy component and set its properties
//        Enemy enemyComponent = enemy.GetComponent<Enemy>();
//        if (enemyComponent != null)
//        {
//            enemyComponent.maxHealth = maxHealth;
//            enemyComponent.speed = speed;
//            enemyComponent.lifetime = lifetime;
//            enemyComponent.bombAmount = bombAmount;
//            enemyComponent.bombDelay = bombDelay;
//            enemyComponent.bombCooldown = bombCooldown;
//        }

//        return enemy;
//    }
//}