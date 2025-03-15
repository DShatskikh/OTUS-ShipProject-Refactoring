using System.Collections.Generic;
using Windows;
using Game.Gameplay.Player;
using GameSystem;
using UnityEngine;

namespace Game.Meta
{
    [AddComponentMenu(UpgradeExtensions.MENU_PATH + "Sawmill Upgrade List Presenter")]
    public class SawmillUpgradeListPresenter : MonoWindow, IGameConstructElement
    {
        [SerializeField]
        private UpgradeView viewPrefab;

        [SerializeField]
        private Transform viewsContainer;

        [SerializeReference]
        public IUpgrade[] upgrades;

        private MoneyStorage moneyStorage;

        private readonly List<SawmillUpgradePresenter> presenters;

        private readonly List<UpgradeView> views;
        
        public SawmillUpgradeListPresenter()
        {
            this.presenters = new List<SawmillUpgradePresenter>();
            this.views = new List<UpgradeView>();
        }
        
        protected override void OnShow(object args)
        {
            this.CreateUpgrades();
            this.ShowUpgrades();
        }

        protected override void OnHide()
        {
            this.DestroyUpgrades();
        }

        private void CreateUpgrades()
        {
            for (int i = 0, count = upgrades.Length; i < count; i++)
            {
                var view = Instantiate(this.viewPrefab, this.viewsContainer);
                this.views.Add(view);

                var model = upgrades[i];
                var presenter = new SawmillUpgradePresenter(model, view);
                presenter.Construct(this.moneyStorage);
                this.presenters.Add(presenter);
            }
        }

        private void ShowUpgrades()
        {
            for (int i = 0, count = this.presenters.Count; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Start();
            }
        }

        private void DestroyUpgrades()
        {
            var count = this.presenters.Count;
            for (var i = 0; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Stop();

                var view = this.views[i];
                Destroy(view.gameObject); //Можно кэшировать
            }

            this.presenters.Clear();
            this.views.Clear();
        }
        
        public void ConstructGame(GameContext context)
        {
            this.moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}