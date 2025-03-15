using System.Collections.Generic;
using UnityEngine;

namespace Leopotam.EcsLite.Entities
{
    public sealed class EntityManager
    {
        private EcsWorld world;

        private readonly Dictionary<int, Entity> entities = new();
        private readonly ObjectPool _objectPool = new();
        
        public void Initialize(EcsWorld world)
        {
            Entity[] entities = GameObject.FindObjectsOfType<Entity>();
            for (int i = 0, count = entities.Length; i < count; i++)
            {
                Entity entity = entities[i];
                entity.Initialize(world);
                this.entities.Add(entity.Id, entity);
            }
            
            this.world = world;
        }

        public Entity Create(Entity prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            Entity entity = GameObject.Instantiate(prefab, position, rotation, parent);
            entity.Initialize(this.world);
            this.entities.Add(entity.Id, entity);
            return entity;
        }
        
        public Entity Get(Entity prefab, Vector3 position, Quaternion rotation, bool isPool, Transform parent = null)
        {
            if (isPool)
            {
                Entity entity = _objectPool.GetObject(prefab.name).GetComponent<Entity>();
                entity.gameObject.name = prefab.name;

                entity.transform.position = position;
                entity.transform.rotation = rotation;
                entity.transform.SetParent(parent);
            
                entity.Initialize(this.world);
                this.entities.Add(entity.Id, entity);
                
                return entity;
            }

            return Create(prefab, position, rotation);
        }
        
        public void Destroy(int id)
        {
            if (this.entities.Remove(id, out Entity entity))
            {
                entity.Dispose();
                
                if (!_objectPool.TryReturnObject(entity.name, entity.gameObject))
                    GameObject.Destroy(entity.gameObject);
            }
        }

        public Entity Get(int id)
        {
            return this.entities[id];
        }
    }
}