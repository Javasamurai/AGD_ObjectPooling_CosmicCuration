using UnityEngine;
using System.Collections.Generic;
using CosmicCuration.Enemy;

namespace CosmicCuration.Enemy {
    public class EnemyPool
    {
        private EnemyView enemyView;
        private EnemyData enemyData;
        private List<PooledEnemy> pooledEnemies = new List<PooledEnemy>();
        public EnemyPool(EnemyView enemyView, EnemyData enemyData)
        {
            this.enemyView = enemyView;
            this.enemyData = enemyData;
        }

        public EnemyController GetEnemy()
        {
            if (pooledEnemies.Count > 0)
            {
                PooledEnemy pooledObject = pooledEnemies.Find(b => !b.isActive);
                if (pooledObject != null)
                {
                    pooledObject.isActive = true;
                    return pooledObject.enemyController;
                }
            }
            return CreateNewEnemies();
        }

        private EnemyController CreateNewEnemies()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
            pooledEnemy.enemyController = new EnemyController(enemyView, enemyData);
            pooledEnemy.isActive = true;
            pooledEnemies.Add(pooledEnemy);
            return pooledEnemy.enemyController;
        }
        
        public void ReturnEnemyToPool(EnemyController enemyController)
        {
            PooledEnemy pooledEnemy = pooledEnemies.Find(b => b.enemyController == enemyController);
            if (pooledEnemy != null)
            {
                pooledEnemy.isActive = false;
            }
        }

        public class PooledEnemy
        {
            public EnemyController enemyController;
            public bool isActive;
        }
    }
}