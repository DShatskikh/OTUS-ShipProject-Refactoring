using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public struct UnitData
    {
        public int ID;
        public string Type;
        public int HitPoints;
        public Vector3 Position;
        public Vector3 Rotation;
    }
}