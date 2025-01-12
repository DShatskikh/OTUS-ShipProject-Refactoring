using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "UnitConfig",
        menuName = "Configs/New UnitConfig"
    )]
    public class UnitConfig : ScriptableObject, IUnitConfig
    {
        [SerializeField]
        private BulletConfig _bulletConfig;

        [SerializeField]
        private int _health;

        public BulletConfig BulletConfig => _bulletConfig;
        public int Health => _health;
    }

    public interface IUnitConfig
    {
        BulletConfig BulletConfig { get; }
        int Health { get; }
    }
}