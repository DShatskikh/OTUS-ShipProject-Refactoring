using System;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    [Serializable]
    public struct InputDirection
    {
        public Vector2 Value;
    }
    
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
    public struct SeePoint
    {
        public Vector2 Value;
    }
    
    [Serializable]
    public struct ShotRequest { }
    
    [Serializable]
    public struct Bullet { }
    
    [Serializable]
    public struct BulletWeapon
    {
        public Transform FirePoint;
        public Entity BulletPrefab;
    }
    
    [Serializable]
    public struct MoveDirection
    {
        public Vector3 Value;
    }
}