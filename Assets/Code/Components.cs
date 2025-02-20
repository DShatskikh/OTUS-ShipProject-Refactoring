using System;
using Leopotam.EcsLite.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    [Serializable]
    public struct Root
    {
        public Transform Value;
    }
    
    [Serializable]
    public struct MoveSpeed
    {
        public float Value;
    }
    
    [Serializable]
    public struct RotationSpeed
    {
        public float Value;
    }
    
    [Serializable]
    public struct MoveDirection
    {
        public Vector3 Value;
    }
    
    [Serializable]
    public struct UnitCommand
    {
        public UnitCommandType Value;
    }
    
    [Serializable]
    public struct UnitTag { }
    
    [Serializable]
    public struct BaseTag { }
    
    [Serializable]
    public struct ArcherTag { }
    
    [Serializable]
    public struct KnightTag { }
    
    [Serializable]
    public struct CreateUnitRequest
    {
        public Entity Prefab;
        public Transform SpawnPoint;
    }
    
    [Serializable]
    public struct Health
    {
        public int Max;
        public int Current;
    }
    
    [Serializable]
    public struct Cooldown
    {
        public float Current;
        public float Max;
    }
    
    [Serializable]
    public struct AttackRadius
    {
        public float Value;
    }
    
    [Serializable]
    public struct AttackTarget
    {
        public Transform Value;
    }
    
    [Serializable]
    public struct MoveState { }
    
    [Serializable]
    public struct AttackState { }
    
    [Serializable]
    public struct ArrowPrefab
    {
        public Entity Value;
    }
    
    [Serializable]
    public struct ArrowTag { }

    [Serializable]
    public struct CollisionEnterRequest
    {
        public Entity Source;
        public Entity Target;
    }

    [Serializable]
    public struct BowPoint
    {
        public Transform Value;
    }
    
    [Serializable]
    public struct SwordTag { }

    [Serializable]
    public struct Sword
    {
        public Entity Value;
    }
    
    [Serializable]
    public struct Damage
    {
        public int Value;
    }
    
    [Serializable]
    public struct DamageRequest
    {
        public int Damage;
        public Entity Target;
    }
    
    [Serializable]
    public struct DeathTag { }
    
    [Serializable]
    public struct AnimatorView
    {
        public Animator Value;
    }
    
    [Serializable]
    public struct DamageParticle
    {
        public ParticleSystem Value;
    }
    
    [Serializable]
    public struct Inactive { }
}