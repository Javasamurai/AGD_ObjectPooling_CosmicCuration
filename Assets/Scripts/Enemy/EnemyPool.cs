using UnityEngine;
using System.Collections.Generic;
using CosmicCuration.Enemy;
using CosmicCuration.Utilities;

namespace CosmicCuration.Enemy {
    public class EnemyPool : GenericObjectPool<EnemyController>
    {
        private EnemyView enemyView;
        private EnemyData enemyData;
        public EnemyPool(EnemyView enemyView, EnemyData enemyData)
        {
            this.enemyView = enemyView;
            this.enemyData = enemyData;
        }

        override protected EnemyController CreateNewItem()
        {
            return new EnemyController(enemyView, enemyData);
        }

        public EnemyController GetEnemy() => GetObject();
        
        public void ReturnEnemyToPool(EnemyController enemyController) => ReturnObjectToPool(enemyController);
    }
}