using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class ZombieInstaller : SceneEntityInstallerBase
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _rotationSpeed;

        [SerializeField]
        private Transform _rootVisual;
        
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private AnimatorDispatcher _animatorDispatcher;
        
        [SerializeField]
        private ParticleSystem _damageVFX;
        
        [SerializeField]
        private AudioSource _damageSound;
        
        public override void Install(IEntity entity)
        {
            entity.AddHitPoints(1);
            entity.AddRoot(transform);
            entity.AddMoveSpeed(_speed);
            entity.AddAnimator(_animator);
            entity.AddAnimatorDispatcher(_animatorDispatcher);
            entity.AddSeePoint(Vector3.zero);
            entity.AddRotationSpeed(_rotationSpeed);
            entity.AddRootVisual(_rootVisual);
            entity.AddDamageRequest(new BaseEvent<int>());
            entity.AddDamageVFX(_damageVFX);
            entity.AddDamageSoundPlayer(_damageSound);
            
            entity.AddBehaviour(new DestroyToZeroHitPointsBehaviour());
            entity.AddBehaviour(new MoveToTargetBehaviour());
            entity.AddBehaviour(new SeePointToTargetBehaviour());
            entity.AddBehaviour(new RotateToSeePointBehaviour());
            entity.AddBehaviour(new AttackTargetBehaviour());
            entity.AddBehaviour(new DamageRequestVFXBehaviour());
            entity.AddBehaviour(new DamageRequestSoundBehaviour());
            entity.AddBehaviour(new DamageRequestBehaviour());
        }
    }
}