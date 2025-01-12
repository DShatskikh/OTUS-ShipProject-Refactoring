using System;
using UnityEngine;

namespace ShootEmUp
{
    public interface ICharacter
    {
        Vector2 GetPosition { get; }
        event Action OnDeath;
    }
}