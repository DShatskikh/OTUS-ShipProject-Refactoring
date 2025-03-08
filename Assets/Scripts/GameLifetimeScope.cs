using System.Collections.Generic;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private Unit[] _redUnits;
        
        [SerializeField]
        private List<Unit> _blueUnits;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<EventBus>(Lifetime.Singleton).AsSelf();
            
            builder.Register<TurnPipeline>(Lifetime.Singleton);
            builder.Register<VisualPipeline>(Lifetime.Singleton);
            builder.Register<UnitsManager>(Lifetime.Singleton).WithParameter(_redUnits).WithParameter(_blueUnits);

            builder.Register<CoroutineRunner>(Lifetime.Singleton).WithParameter((MonoBehaviour)this).As<ICoroutineRunner>().AsSelf();
            builder.RegisterEntryPoint<TurnPipelineInstaller>();
            builder.RegisterComponentInHierarchy<TurnPipelineRunner>();
            builder.RegisterComponentInHierarchy<EndGameScreen>();
            builder.RegisterComponentInHierarchy<AudioPlayer>();
            
            builder.RegisterEntryPoint<AttackHandler>();
            builder.RegisterEntryPoint<PassiveAbilityHandler>();
            builder.RegisterEntryPoint<DamageHandler>();
            builder.RegisterEntryPoint<DestroyHandler>();
            builder.RegisterEntryPoint<SoundPlayHandler>();
        }
    }
}