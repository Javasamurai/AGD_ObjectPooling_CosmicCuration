namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private System.Collections.Generic.List<PooledObject<T>> pooledObjects = new System.Collections.Generic.List<PooledObject<T>>();

        public T GetObject()
        {
            if (pooledObjects.Count > 0)
            {
                PooledObject<T> pooledObject = pooledObjects.Find(b => !b.isActive);
                if (pooledObject != null)
                {
                    pooledObject.isActive = true;
                    return pooledObject.obj;
                }
            }
            return CreateNewObject();
        }

        public T CreateNewObject()
        {
            PooledObject<T> pooledObject = new PooledObject<T>();
            pooledObject.obj = CreateNewItem();
            pooledObject.isActive = true;
            pooledObjects.Add(pooledObject);
            return pooledObject.obj;
        }

        protected virtual T CreateNewItem()
        {
            throw new System.NotImplementedException();
        }

        public void ReturnObjectToPool(T obj)
        {
            PooledObject<T> pooledObject = pooledObjects.Find(b => b.obj == obj);
            if (pooledObject != null)
            {
                pooledObject.isActive = false;
            }
        }

        public class PooledObject<T>
        {
            public T obj;
            public bool isActive;
        }  
    }
}