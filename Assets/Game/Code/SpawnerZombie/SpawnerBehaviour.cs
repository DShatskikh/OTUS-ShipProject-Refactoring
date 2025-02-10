using Atomic.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public sealed class SpawnerBehaviour : IEntityInit, IEntityUpdate
    {
        private const float TARGET_DURATION = 2f;
        
        private float _timer = 0f;
        private SceneEntity _prefab;
        private Transform[] _points;

        public void Init(IEntity entity)
        {
            _prefab = entity.GetPrefab();
            _points = entity.GetPoints();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (_timer >= TARGET_DURATION)
            {
                var point = _points[Random.Range(0, _points.Length)];
                Object.Instantiate(_prefab, point.position, quaternion.identity, point);
                _timer = 0;
            }
            else
            {
                _timer += deltaTime;
            }
        }
    }
}