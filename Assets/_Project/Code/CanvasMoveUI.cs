using UnityEngine;

namespace _Project.Code
{
    public sealed class CanvasMoveUI : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;

        [SerializeField]
        private float _addY;
        
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            var screenPosition = _camera.WorldToScreenPoint(_target.position + new Vector3(0, _addY, 0));
            transform.position = screenPosition;
        }
    }
}