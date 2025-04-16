using UnityEngine;
using UnityEngine.AI;

namespace _Project.Code
{
    public sealed class NavigationMover : MonoBehaviour
    {
        [SerializeField]
        private float _stopDistance = 0.5f;

        [SerializeField]
        private float _speed = 2;

        [SerializeField]
        private float _rotationSpeed = 100;
        
        private Vector3 _target;
        private NavMeshPath _path;
        private float _elapsed;
        private bool _isMove;
        private bool _isRotate;
        private int _pointIndex;

        public bool GetIsMove => _isMove;
        public bool GetIsRotate => _isRotate;
        
        private void Awake()
        {
            _path = new NavMeshPath();
            _elapsed = 0.0f;
        }

        private void Update()
        {
            if (!_isMove)
                return;

            _elapsed += Time.deltaTime;
            
            if (_elapsed > 1.0f)
            {
                CreatePath();
            }
            
            Move();
        }

        public void StartMove(Vector3 point)
        {
            _isMove = true;
            _target = point;
            CreatePath();
        }

        public void StopMove()
        {
            _isMove = false;
        }

        private void CreatePath()
        {
            _elapsed = 0;
            var point = _target;
            
            if (NavMesh.SamplePosition(_target, out NavMeshHit hit, 2, NavMesh.AllAreas))
            {
                point = hit.position;
            }
            
            NavMesh.CalculatePath(transform.position, point, NavMesh.AllAreas, _path);
            _pointIndex = 1;

            if (_path.corners.Length == 0)
                _isMove = false;
        }

        private void Move()
        {
            if (_path.corners.Length > _pointIndex)
            {
                if (Vector3.Distance(transform.position, _path.corners[_pointIndex]) > _stopDistance)
                {
                    Vector3 currentWaypoint = _path.corners.Length == _pointIndex + 1 ? _target : _path.corners[_pointIndex];
                    Vector3 direction = currentWaypoint - transform.position;
                    direction.y = 0;

                    if (direction != Vector3.zero)
                    {
                        _isRotate = true;
                        
                        Quaternion targetRotation = Quaternion.LookRotation(direction);
                        transform.rotation = Quaternion.RotateTowards(
                            transform.rotation,
                            targetRotation,
                            _rotationSpeed * Time.deltaTime);
                        
                        if (transform.rotation != targetRotation)
                            return;
                    }

                    _isRotate = false;
                    transform.position -= Vector3.Normalize(transform.position - _path.corners[_pointIndex]) * _speed *
                                          Time.deltaTime;
                }
                else
                {
                    _pointIndex++;

                    if (_path.corners.Length >= _pointIndex)
                    {
                        _isMove = false;
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (_path != null && _path.corners.Length > 0)
            {
                for (int i = 0; i < _path.corners.Length - 1; i++)
                    Debug.DrawLine(_path.corners[i], _path.corners[i + 1], Color.red);
            }
        }
    }
}