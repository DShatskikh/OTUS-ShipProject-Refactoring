using Game.App;
using Game.Gameplay.Player;
using Game.Localization;
using UnityEngine;

namespace Game.Meta
{
    public class SawmillUpgradePresenter
    {
        private const string UPGRADE_COLOR_HEX = "309D1E";

        private readonly IUpgrade upgrade;

        private readonly UpgradeView view;

        private MoneyStorage moneyStorage;

        public SawmillUpgradePresenter(IUpgrade upgrade, UpgradeView view)
        {
            this.upgrade = upgrade;
            this.view = view;
        }

        public void Construct(MoneyStorage moneyStorage)
        {
            this.moneyStorage = moneyStorage;
        }

        public void Start()
        {
            this.view.SetIcon(this.upgrade.Metadata.GetIcon);
            this.view.UpgradeButton.AddListener(this.OnButtonClicked);

            this.upgrade.OnLevelUp += this.OnLevelUp;
            this.moneyStorage.OnMoneyChanged += this.OnMoneyChanged;

            var language = LanguageManager.CurrentLanguage;
            this.UpdateTitle(language);
            this.UpdateLevel(language);
            this.UpdateStats(language);
            this.UpdateButtonPrice();
            this.UpdateButtonState();
            LanguageManager.OnLanguageChanged += this.OnUpdateLanguage;
        }

        public void Stop()
        {
            this.view.UpgradeButton.RemoveListener(this.OnButtonClicked);
            this.upgrade.OnLevelUp -= this.OnLevelUp;
            this.moneyStorage.OnMoneyChanged -= this.OnMoneyChanged;
            LanguageManager.OnLanguageChanged -= this.OnUpdateLanguage;
        }

        #region UIEvents

        private void OnButtonClicked()
        {
            if (this.upgrade.CanLevelUp)
            {
                this.upgrade.LevelUp();
            }
        }

        #endregion

        #region ModelEvents

        private void OnLevelUp(int level)
        {
            var language = LanguageManager.CurrentLanguage;
            this.UpdateLevel(language);
            this.UpdateStats(language);
            this.UpdateButtonPrice();
            this.UpdateButtonState();
        }

        private void OnMoneyChanged(int newValue)
        {
            this.UpdateButtonState();
        }

        private void OnUpdateLanguage(SystemLanguage language)
        {
            this.UpdateTitle(language);
            this.UpdateLevel(language);
            this.UpdateStats(language);
        }

        #endregion

        private void UpdateTitle(SystemLanguage language)
        {
            var titleKey = this.upgrade.Metadata.GetLocalizedTitle;
            var title = LocalizationManager.GetText(titleKey, language);
            this.view.SetTitle(title);
        }

        private void UpdateLevel(SystemLanguage language)
        {
            var title = LocalizationManager.GetText(LocalizationKeys.Common.LEVEL_KEY, language);
            var levelText = $"{title}: {this.upgrade.GetLevel}/{this.upgrade.GetMaxLevel}";
            this.view.SetLevel(levelText);
        }
        
        private void UpdateStats(SystemLanguage language)
        {
            var title = LocalizationManager.GetText(LocalizationKeys.Common.VALUE_KEY, language);
            var statsText = $"{title}: {this.upgrade.CurrentStats}";
            
            if (!this.upgrade.IsMaxLevel)
            {
                if (this.upgrade.NextImprovement >= 0)
                    statsText += $" <color=#{UPGRADE_COLOR_HEX}>(+{this.upgrade.NextImprovement})</color>";
                else
                    statsText += $" <color=RED>({this.upgrade.NextImprovement})</color>";
            }
            
            this.view.SetStats(statsText);
        }

        private void UpdateButtonPrice()
        {
            var priceText = this.upgrade.GetPrice.ToString();
            this.view.UpgradeButton.SetPrice(priceText);
        }

        private void UpdateButtonState()
        {
            var upgradeButton = this.view.UpgradeButton;
            if (this.upgrade.IsMaxLevel)
            {
                upgradeButton.SetState(UpgradeButton.State.MAX);
                return;
            }

            var state = this.upgrade.GetPrice <= this.moneyStorage.Money
                ? UpgradeButton.State.AVAILABLE
                : UpgradeButton.State.LOCKED;

            upgradeButton.SetState(state);
        }
    }
}