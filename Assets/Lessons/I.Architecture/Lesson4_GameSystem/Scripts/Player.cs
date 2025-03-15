using UnityEngine;

namespace Lessons.Architecture.GameSystem
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 2.5f;

        [SerializeField] private Animator _animator;

        public void Move(Vector3 offset)
        {
            transform.position += offset * _speed;
            _animator.SetBool("IsMoving", offset.sqrMagnitude > Mathf.Epsilon);
        }
    }
}