using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Lessons.Lesson_Components
{
    [Serializable]
    public class ShootComponent
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _firePoint;

        public void Shoot()
        {
            Debug.Log("Fire!");
            var bullet = Object.Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);

            if (bullet.TryGetComponent(out MoveComponent moveComponent))
            {
                moveComponent.SetDirection(_firePoint.forward);
            }
        }
    }
}