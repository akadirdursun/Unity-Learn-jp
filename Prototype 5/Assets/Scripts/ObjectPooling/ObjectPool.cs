using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClickyMause
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private PoolObjectStruct[] pools;

        private void Awake()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].PoolObjects = new Queue<GameObject>();
                for (int j = 0; j < pools[i].PoolSize; j++)
                {
                    var obj = Instantiate(pools[i].ObjectPrefab, transform);
                    pools[i].PoolObjects.Enqueue(obj);
                    obj.SetActive(false);
                }
            }
        }

        public GameObject GetRandomPoolObject()
        {
            int index = Random.Range(0, pools.Length);
            if (pools[index].PoolObjects.Peek().activeInHierarchy)
            {
                GameObject newObj = Instantiate(pools[index].ObjectPrefab, transform);
                pools[index].PoolObjects.Enqueue(newObj);
                newObj.SetActive(false);
                return newObj;
            }
            GameObject obj = pools[index].PoolObjects.Dequeue();
            pools[index].PoolObjects.Enqueue(obj);
            return obj;
        }
    }
}