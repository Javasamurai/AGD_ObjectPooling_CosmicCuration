using UnityEngine;
using System.Collections.Generic;

namespace CosmicCuration.Bullets {
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();
        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public BulletController GetBullet()
        {
            if (pooledBullets.Count > 0)
            {
                PooledBullet pooledObject = pooledBullets.Find(b => !b.isActive);
                if (pooledObject != null)
                {
                    pooledObject.isActive = true;
                    return pooledObject.bulletController;
                }
            }
            return CreateNewPooledBullet();
        }

        private BulletController CreateNewPooledBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.bulletController = new BulletController(bulletView, bulletScriptableObject);
            pooledBullet.isActive = true;
            return pooledBullet.bulletController;
        }

        public class PooledBullet
        {
            public BulletController bulletController;
            public bool isActive;
        }
    }
}