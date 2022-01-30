using System.Collections.Generic;
using UnityEngine;

namespace Game.ObjectPooling
{
    /// <summary>
    /// This could be done better, by providing generics to get specific classes. But its a rush rn
    /// </summary>
    public class ObjectPool : MonoBehaviour
    {
        public GameObject PoolObjectPrefab;

        public Stack<GameObject> pooledObjects = new Stack<GameObject>();

        public GameObject Get()
        {
            if (pooledObjects.Count == 0)
            {
                var go = Instantiate(PoolObjectPrefab);
                return go;
            }

            var gop = pooledObjects.Pop();
            gop.SetActive(true);
            
            return gop;
        }

        public void Push(GameObject pooledObject)
        {
            pooledObject.SetActive(false);
            
            pooledObjects.Push(pooledObject);
        }
        
        

    }
}