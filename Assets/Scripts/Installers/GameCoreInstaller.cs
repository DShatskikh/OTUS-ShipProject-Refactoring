using GameCycle;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "New GameCoreInstaller", menuName = "Installers/GameCoreInstaller", order = 0)]
    public class GameCoreInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameStateController>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
        }
    }
}