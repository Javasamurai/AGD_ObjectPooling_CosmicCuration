using UnityEngine;
using System.Collections.Generic;
using CosmicCuration.Utilities;

namespace CosmicCuration.Bullets {
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        protected override BulletController CreateNewItem()
        {
            return new BulletController(bulletView, bulletScriptableObject);
        }

        public BulletController GetBullet() => GetObject();     
        public void ReturnBulletToPool(BulletController bulletController) => ReturnObjectToPool(bulletController);
    }
}