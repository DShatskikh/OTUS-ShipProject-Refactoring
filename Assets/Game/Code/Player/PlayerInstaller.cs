using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class PlayerInstaller : SceneEntityInstallerBase
    {
        [SerializeField]
        private Transform _root;
        
        [SerializeField]
        private Transform _rootVisual;
        
        [SerializeField]
        private float _moveSpeed;
        
        [SerializeField]
        private float _rotationSpeed;

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
            entity.AddRoot(_root);
            entity.AddRootVisual(_rootVisual);
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddRotationSpeed(_rotationSpeed);
            entity.AddAnimator(_animator);
            entity.AddIsShot(false);
            entity.AddAnimatorDispatcher(_animatorDispatcher);
            entity.AddAmmo(4);
            entity.AddMaxAmmo(4);
            entity.AddHitPoints(4);
            entity.AddKills(0);
            entity.AddShotCooldown(0.5f);
            entity.AddInputDirection(Vector2.zero);
            entity.AddIsShotPress(false);
            entity.AddSeePoint(new Vector3());
            entity.AddDamageRequest(new BaseEvent<int>());
            entity.AddDamageVFX(_damageVFX);
            entity.AddDamageSoundPlayer(_damageSound);
            
            entity.AddBehaviour(new MoveToInputBehaviour());
            entity.AddBehaviour(new DamageRequestVFXBehaviour());
            entity.AddBehaviour(new DamageRequestSoundBehaviour());
            entity.AddBehaviour(new DamageRequestBehaviour());
            entity.AddBehaviour(new RotateToSeePointBehaviour());
            entity.AddBehaviour(new ShotBehaviour());

            var addAmmoTimer = new Timer(0.5f, true);
            addAmmoTimer.OnEnded += () =>
            {
                if (entity.GetAmmo().Value >= entity.GetMaxAmmo())
                    return;
                
                entity.GetAmmo().Value += 1;
            };
            entity.WhenUpdate(addAmmoTimer.Tick);
            addAmmoTimer.Play();
        }
    }
}