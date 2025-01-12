using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private CharacterController _character;
        
        [SerializeField]
        private LevelBounds _bounds;

        public override void InstallBindings()
        {
            Container.Bind<LevelBounds>().FromInstance(_bounds).AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterController>().FromInstance(_character).AsSingle();
        }
    }
}