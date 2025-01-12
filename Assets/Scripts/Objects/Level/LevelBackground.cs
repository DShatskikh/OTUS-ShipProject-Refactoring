using GameCycle;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour, IGameStartListener, IGameFixedUpdateListener
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

        public void OnStartGame()
        {
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        public void FixedTick(float delta)
        {
            if (_myTransform.position.y <= _endPositionY)
                _myTransform.position = new Vector3(_positionX, _startPositionY, _positionZ);

            _myTransform.position -= new Vector3(_positionX, _movingSpeedY * delta, _positionZ);
        }
    }
}