using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public sealed class OrcArcherInstaller : EntityInstaller
    {
        [SerializeField]
        private float _moveSpeed = 5;
        
        [SerializeField]
        private float _rotationSpeed = 5;
        
        [SerializeField]
        private float _attackRadius = 5;
        
        [SerializeField]
        private int _health = 5;
        
        [SerializeField]
        private float _cooldown = 15;

        [SerializeField]
        private Entity _arrowPrefab;

        [SerializeField]
        private Transform _bowPoint;
        
        [SerializeField]
        private Animator _animator;
        
        [SerializeField]
        private ParticleSystem _damageParticle;
        
        protected override void Install(Entity entity)
        {
            entity.AddData(new UnitTag());
            entity.AddData(new ArcherTag());
            entity.AddData(new Root { Value = transform });
            entity.AddData(new MoveSpeed { Value = _moveSpeed });
            entity.AddData(new RotationSpeed { Value = _rotationSpeed });
            entity.AddData(new UnitCommand { Value = UnitCommandType.Orc });
            entity.AddData(new Health { Current = _health, Max = _health });
            entity.AddData(new Cooldown { Current = 0, Max = _cooldown });
            entity.AddData(new AttackRadius { Value = _attackRadius });
            entity.AddData(new MoveState());
            entity.AddData(new ArrowPrefab() { Value = _arrowPrefab });
            entity.AddData(new BowPoint() { Value = _bowPoint });
            entity.AddData(new AnimatorView { Value = _animator });
            entity.AddData(new DamageParticle { Value = _damageParticle });
        }

        protected override void Dispose(Entity entity)
        {
            
        }
    }
}