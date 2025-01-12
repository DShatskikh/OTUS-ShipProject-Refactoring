using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        
        [SerializeField]
        private Transform _firePoint;
        
        [SerializeField]
        private UnitConfig _unitConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<MoveComponent>().AsSingle().WithArguments(_rigidbody2D);
            Container.Bind<WeaponComponent>().AsSingle().WithArguments(_firePoint);
            Container.Bind<IUnitConfig>().FromInstance(_unitConfig).AsSingle();
        }
    }
}