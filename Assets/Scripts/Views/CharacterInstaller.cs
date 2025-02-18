using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public sealed class CharacterInstaller : EntityInstaller
    {
        [SerializeField]
        private float _moveSpeed = 5.0f;
        
        [SerializeField]
        private float _rotationSpeed = 5.0f;
        
        [SerializeField]
        private Transform _firePoint;

        [SerializeField]
        private Entity _bulletPrefab;

        private Entity _entity;

        protected override void Install(Entity entity)
        {
            _entity = entity;
            _entity.AddData(new InputDirection {Value = Vector2.zero});
            _entity.AddData(new Root {Value = transform});
            _entity.AddData(new MoveSpeed {Value = _moveSpeed});
            _entity.AddData(new RotationSpeed {Value = _rotationSpeed});
            _entity.AddData(new SeePoint {Value = Vector2.zero});
            _entity.AddData(new BulletWeapon {FirePoint = _firePoint, BulletPrefab = _bulletPrefab});
        }

        private void Update()
        {
            _entity.SetData(new InputDirection {Value = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized});
            
            var mousePosition = Input.mousePosition;
            var ray = Camera.main.ScreenPointToRay(mousePosition);
            var seePoint = ray.GetPoint(11);
            
            _entity.SetData(new SeePoint {Value = seePoint});
            
            if (Input.GetMouseButtonDown(0))
                _entity.SetData(new ShotRequest());
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}