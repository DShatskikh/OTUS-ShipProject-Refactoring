using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public sealed class OrcKnightInstaller : EntityInstaller
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
        private Entity _sword;
        
        [SerializeField]
        private Animator _animator;
        
        [SerializeField]
        private ParticleSystem _damageParticle;
        
        protected override void Install(Entity entity)
        {
            entity.AddData(new UnitTag());
            entity.AddData(new KnightTag());
            entity.AddData(new Root { Value = transform });
            entity.AddData(new MoveSpeed { Value = _moveSpeed });
            entity.AddData(new RotationSpeed { Value = _rotationSpeed });
            entity.AddData(new UnitCommand { Value = UnitCommandType.Orc });
            entity.AddData(new Health { Current = _health, Max = _health });
            entity.AddData(new Cooldown { Current = 0, Max = _cooldown });
            entity.AddData(new AttackRadius { Value = _attackRadius });
            entity.AddData(new MoveState());
            entity.AddData(new AnimatorView { Value = _animator });
            entity.AddData(new DamageParticle { Value = _damageParticle });
            
            _sword.Initialize(entity.GetWorld());
            entity.AddData(new Sword() { Value = _sword });
        }

        protected override void Dispose(Entity entity) { }
    }
}