using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private LevelBounds _bounds;

        [SerializeField]
        private CharacterController _characterPrefab;

        public override void InstallBindings()
        {
            Container.Bind<LevelBounds>().FromInstance(_bounds).AsSingle();
            Container.BindInterfacesAndSelfTo<GameStateController>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterController>().FromComponentInNewPrefab(_characterPrefab).AsSingle();
            //Container.BindInterfacesAndSelfTo<CharacterController>().FromComponentInNewPrefab(_characterPrefab).AsSingle();
        }
    }
}