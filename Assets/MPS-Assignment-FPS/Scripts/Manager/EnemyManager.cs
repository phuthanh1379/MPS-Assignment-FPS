using System;
using System.Collections.Generic;
using Scripts.Enemy;
using UnityEngine;
using Random = System.Random;

namespace Scripts.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
        [SerializeField] private GameObject bloodSplatterFx;

        [SerializeField] private List<EnemyController> enemies = new List<EnemyController>();
        
        private void SpawnEnemy()
        {
            var randPos = new Random();
            var enemy = 
                Instantiate(enemyPrefabs[randPos.Next(0, enemyPrefabs.Count - 1)], transform).AddComponent<EnemyController>();
            enemy.tag = "Enemy";
            var randRot = new Random();
            enemy.Init(bloodSplatterFx, randRot.Next(0, 360));
            enemies.Add(enemy);
        }

        public void Init(int numberOfEnemies)
        {
            for (var i = 0; i < numberOfEnemies; i++)
            {
                SpawnEnemy();
            }
        }
    }
}