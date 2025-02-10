using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class ShotBehaviour : IEntityInit, IEntityUpdate
    {
        private static readonly int State = Animator.StringToHash("State");

        public void Init(IEntity entity)
        {
            var input = SceneContext.Instance.GetPlayerInput();
            var animator = entity.GetAnimator();
            var animatorDispatcher = entity.GetAnimatorDispatcher();
            var rootVisual = entity.GetRootVisual();

            input.actions["Fire"].started += context =>
            {
                var cooldown = entity.GetShotCooldown();
                var ammo = entity.GetAmmo();
                
                if (ammo.Value <= 0 && cooldown <= 0)
                    return;
                
                animator.SetFloat(State, 2);
                entity.SetIsShot(true);
            };
            
            animatorDispatcher.SubscribeOnEvent("Shot", () =>
            {
                if (entity.GetAmmo().Value <= 0 )
                    return;
                
                entity.GetAmmo().Value -= 1;
                entity.SetShotCooldown(0.5f);
                Debug.Log($"shot <{entity.GetAmmo().Value}>");

                Ray ray = new Ray(rootVisual.position, rootVisual.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f))
                {
                    var component = hit.collider.GetComponent<SceneEntityProxy>();

                    if (component != null)
                    {
                        Debug.Log("hit");
                        entity.GetKills().Value += 1;
                        component.GetHitPoints().Value -= 1;
                    }
                }
            });

            entity.GetAmmo().Subscribe(count =>
            {
                if (entity.GetAmmo().Value > 0 )
                    return;
                
                animator.SetFloat(State, 0);
                entity.SetIsShot(false);
            });
            
            input.actions["Fire"].canceled += context =>
            {
                animator.SetFloat(State, 0);
                entity.SetIsShot(false);
            };
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            var cooldown = entity.GetShotCooldown();
            
            if (cooldown > 0)
                entity.SetShotCooldown(cooldown - deltaTime);
        }
    }
}