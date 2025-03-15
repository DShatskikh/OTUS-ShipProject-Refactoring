using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    // [Serializable]
    // public class TransformTargetComponent
    // {
    //     [SerializeField] private Transform _root;
    //     [SerializeField] private float _radius;
    //     [SerializeField] private Transform[] _targets;
    //
    //     public Transform GetTargetPoint()
    //     {
    //         return _root;
    //     }
    // }
    
    [Serializable]
    public class PhysicFindTargetComponent
    {
        private Transform _root;
        private float _radius;
        private LayerMask _layerMask;

        public PhysicFindTargetComponent(Transform root, float radius, LayerMask layerMask)
        {
            _root = root;
            _radius = radius;
            _layerMask = layerMask;
        }

        public Transform GetTargetPoint()
        {
            var colliders = new Collider[10];
            var size = Physics.OverlapSphereNonAlloc(_root.position, _radius, colliders, _layerMask);

            //Нашли цель
            
            return _root;
        }
    }

    public class TowerBehaviour : IEntityInit, IEntityUpdate
    {
        private AtomicEvent _shootAction;
        private ReactiveVariable<Vector3> _rotateDirection;
        private ReactiveFloat _radius;
        private ReactiveVariable<Transform> _targetPoint;
        private Transform _root;
        
        public void Init(IEntity entity)
        {
            _shootAction = entity.GetShootAction();
            _rotateDirection = entity.GetRotateDirection();
            _root = entity.GetRoot();
            _radius = entity.GetDetectRadius();
            _targetPoint = entity.GetTargetPoint();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            var direction = _targetPoint.Value.position - _root.position;
            _rotateDirection.Value = direction;

            if (direction.magnitude < _radius.Value)
            {
                _shootAction.Invoke();
            }
        }
    }
    
    public class Tower : MonoBehaviour
    {
        [SerializeField] private RotationComponent _rotationComponent;
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private ShootComponent _shootComponent;

        [SerializeField] private Transform _targetPoint;
        [SerializeField] private float _radius;

        private void Awake()
        {
            _rotationComponent.Condition.AddCondition(_lifeComponent.IsAlive);
            _shootComponent.CanFire.AddCondition(_lifeComponent.IsAlive);
        }

        private void Update()
        {
            _shootComponent.OnUpdate(Time.deltaTime);
            
            var direction = _targetPoint.position - transform.position;
            _rotationComponent.Rotate(direction);

            if (direction.magnitude < _radius)
            {
                _shootComponent.Shoot();
            }
        }
    }
}