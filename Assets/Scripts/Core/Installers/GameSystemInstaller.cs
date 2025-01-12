using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "GameSystemInstaller", menuName = "Installers/New GameSystemInstaller", order = 0)]
    public class GameSystemInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameStateController>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
        }
    }
}