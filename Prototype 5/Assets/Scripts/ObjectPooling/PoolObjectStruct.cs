using UnityEngine;
using System.Collections.Generic;

namespace ClickyMause
{
    [System.Serializable]
    public struct PoolObjectStruct
    {
        [SerializeField] private Queue<GameObject> poolObjects;
        [SerializeField] private GameObject objectPrefab;
        [SerializeField] private int poolStartingSize;

        public Queue<GameObject> PoolObjects { get => poolObjects; set { poolObjects = value; } }

        public GameObject ObjectPrefab { get => objectPrefab; }
        public int PoolSize { get => poolStartingSize; }
    }
}