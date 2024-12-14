using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour
    {
        [SerializeField]
        private float _startPositionY = 19;
        
        [SerializeField]
        private float _endPositionY = 38;
        
        [SerializeField]
        private float _movingSpeedY = 5;
        
        private float _positionX;
        private float _positionZ;
        private Transform _myTransform;

        private void Awake()
        {
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        private void FixedUpdate()
        {
            if (_myTransform.position.y <= _endPositionY)
                _myTransform.position = new Vector3(_positionX, _startPositionY, _positionZ);

            _myTransform.position -= new Vector3(_positionX, _movingSpeedY * Time.fixedDeltaTime, _positionZ);
        }
    }
}