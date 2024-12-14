using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class MoveComponent
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private float _speed = 5.0f;

        public void MoveByRigidbodyVelocity(Vector2 direction)
        {
            var nextPosition = _rigidbody2D.position + direction * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }
    }
}