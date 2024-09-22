using UnityEngine;

namespace CosmicCuration.Bullets {
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledObject> pooledObjects = new List<PooledObject>();
        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }
        public class Pooleable
        {
            public BulletController gameObject;
            public bool isActive;
        }
    }
}