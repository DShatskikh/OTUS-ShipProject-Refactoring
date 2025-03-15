using System;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class CanMoveConditionAsset : IEntityConditionAsset
    {
        public Func<bool> Create(IEntity entity)
        {
            return () => entity.GetMoveDirection().Value.sqrMagnitude > 0;
        }
    }

    public class CharacterInstaller : SceneEntityInstallerBase
    {
        [SerializeField] private Transform _root;
        [SerializeField] private ReactiveVariable<float> _moveSpeed;

        [SerializeField] private LifeInstaller _lifeInstaller;
        [SerializeField] private RotationInstaller _rotationInstaller;
        [SerializeField] private ShootInstaller _shootInstaller;
        [SerializeField] private AndExpression_EntityInstaller _expressionEntityInstaller;
       
        public override void Install(IEntity entity)
        {
            entity.AddRoot(_root);
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddMoveDirection(new ReactiveVariable<Vector3>());

            _expressionEntityInstaller.Install(entity);
            _lifeInstaller.Install(entity);
            _rotationInstaller.Install(entity);

            entity.AddBehaviour(new MovementBehaviour());
            
            _shootInstaller.Install(entity);
        }
    }
}