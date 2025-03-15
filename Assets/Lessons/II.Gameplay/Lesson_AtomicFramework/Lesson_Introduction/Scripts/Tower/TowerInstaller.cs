using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class TowerInstaller : SceneEntityInstallerBase
    {
        [SerializeField] private Transform _root;
        [SerializeField] private ReactiveFloat _detectRadius;
        [SerializeField] private Transform _target;

        [SerializeField] private LifeInstaller _lifeInstaller;
        [SerializeField] private ShootInstaller _shootInstaller;
        [SerializeField] private RotationInstaller _rotationInstaller;
        
        public override void Install(IEntity entity)
        {
            entity.AddRoot(_root);
            entity.AddDetectRadius(_detectRadius);
            entity.AddTargetPoint(new ReactiveVariable<Transform>(_target));
            _shootInstaller.Install(entity);
            _rotationInstaller.Install(entity);
            _lifeInstaller.Install(entity);

            entity.AddBehaviour(new TowerBehaviour());
        }
    }
}