using System;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    [Serializable]
    public class CharacterInstaller : IEntityInstaller
    {
        public ReactiveVariable<int> HitPoints;
        public ReactiveVariable<bool> IsDead;
        public AndExpression CanTakeDamage;
        public BaseEvent<int> TakeDamageAction;

        [Header("Movement")] 
        public ReactiveVariable<float> MoveSpeed;
        public ReactiveVariable<Vector3> MoveDirection;
        public AndExpression CanMove;
        public Transform Root;
        
        [Header("Rotation")] 
        public ReactiveVariable<float> RotateRate;
        public ReactiveVariable<Vector3> RotateDirection;
        public AndExpression CanRotate;
        public Transform VisualRoot;

        [Header("Shoot")] 
        public ShootBehaviour ShootBehaviour;
        public AndExpression CanFire;
        public BaseEvent ShootAction;
        
        public void Install(IEntity entity)
        {
            //Данные
            entity.AddHitPoints(HitPoints);
            entity.AddIsDead(IsDead);
            entity.AddCanTakeDamage(CanTakeDamage);
            
            entity.AddMoveSpeed(MoveSpeed);
            entity.AddMoveDirection(MoveDirection);
            entity.AddCanMove(CanMove);
            entity.AddTransform(Root);

            entity.AddRotateRate(RotateRate);
            entity.AddRotateDirection(RotateDirection);
            entity.AddCanRotate(CanRotate);
            entity.AddVisualTransform(VisualRoot);

            entity.AddCanFire(CanFire);
            entity.AddShootAction(ShootAction);
            entity.AddShootEvent(new BaseEvent());
            
            CanTakeDamage.Append(() => !IsDead.Value);
            CanMove.Append(() => !IsDead.Value);
            CanFire.Append(()=> !IsDead.Value);
            
            entity.AddTakeDamageAction(TakeDamageAction);
            
            //Логика
            entity.AddBehaviour(new HitPointsMechanics());
            entity.AddBehaviour(new TakeDamageBehaviour());
            entity.AddBehaviour(new MovementBehaviour());
            entity.AddBehaviour(new RotationBehaviour());
            entity.AddBehaviour(ShootBehaviour);
        }
    }
    
    public class IsAliveConditionAsset : IEntityConditionAsset
    {
        public Func<bool> Create(IEntity entity)
        {
            return () => !entity.GetIsDead().Value;
        }
    }
}