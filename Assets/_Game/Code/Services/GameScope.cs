using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public sealed class GameScope : LifetimeScope
    {
        [SerializeField]
        private PastSessionsView _pastSessionsView;

        [SerializeField]
        private ChestConfig[] _configs;

        [SerializeField]
        private ChestView[] _chestViews;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SessionTimeSystem>(Lifetime.Singleton);
            builder.Register<PastSessionsPresenter>(Lifetime.Singleton).WithParameter(_pastSessionsView).AsImplementedInterfaces();

            var chestPresenters = new List<ChestPresenter>(); 
            
            for (int i = 0; i < _configs.Length; i++)
            {
                var chestPresenter = new ChestPresenter(_chestViews[i], _configs[i]);
                chestPresenters.Add(chestPresenter);
                
                builder.Register<ITickable>(_ => chestPresenter, Lifetime.Scoped);
            }
            
            builder
                .RegisterInstance(chestPresenters)
                .As<IEnumerable<ChestPresenter>>();
        }

        private void Start()
        {
            if (Container.TryResolve(out PastSessionsPresenter pastSessionsPresenter)) { }
        }
    }
}