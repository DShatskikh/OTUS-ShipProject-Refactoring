using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletInstaller : MonoInstaller
    {
        [SerializeField]
        private Transform _container;
        
        [SerializeField]
        private Transform _worldTransform;

        [SerializeField]
        private Bullet _bulletPrefab;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BulletSystem>().AsSingle();

            Container.BindMemoryPool<Bullet, Bullet.Pool>()
                .WithInitialSize(25)
                .WithFactoryArguments(_container, _worldTransform)
                .FromComponentInNewPrefab(_bulletPrefab)
                .AsCached();
        }
    }
}