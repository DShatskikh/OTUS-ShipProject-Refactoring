using System.Collections.Generic;
using UnityEngine;

namespace Leopotam.EcsLite.Entities
{
    public sealed class ObjectPool
    {
        private Dictionary<string, List<GameObject>> pools = new();
        
        public GameObject GetObject(string poolName)
        {
            if (!pools.ContainsKey(poolName))
            {
                pools.Add(poolName, new List<GameObject>());
                //return null;
            }

            foreach (GameObject obj in pools[poolName])
            {
                if (!obj.activeSelf)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
            
            GameObject newObject = Object.Instantiate(Resources.Load<GameObject>(poolName));
            newObject.SetActive(true);
            pools[poolName].Add(newObject);
            return newObject;
        }

        // Возврат объекта в пул
        public bool TryReturnObject(string poolName, GameObject obj)
        {
            if (pools.ContainsKey(poolName))
            {
                obj.SetActive(false);
                return true;
            }
            else
            {
                Debug.Log($"Пул {poolName} не существует!");
                return false;
            }
        }

        // Уничтожение пула
        public void DestroyPool(string poolName)
        {
            if (pools.ContainsKey(poolName))
            {
                foreach (GameObject obj in pools[poolName])
                {
                    Object.Destroy(obj);
                }

                pools.Remove(poolName);
            }
        }
    }
}