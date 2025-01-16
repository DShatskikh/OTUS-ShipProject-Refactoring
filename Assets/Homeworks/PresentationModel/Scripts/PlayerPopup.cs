using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerPopup : BasePopup
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TMP_Text _nameLabel;
        
        [SerializeField]
        private TMP_Text _descriptionLabel;
        
        [SerializeField]
        private TMP_Text _levelLabel;

        [SerializeField]
        private TMP_Text _levelProgressLabel;
        
        [SerializeField]
        private Slider _levelProgressSlider;
        
        [SerializeField]
        private Button _levelUpButton;
        
        [SerializeField]
        private Button _closeButton;

        [Header("Stat")]
        [SerializeField]
        private Transform _statContainer;
        
        [SerializeField]
        private CharacterStatView _statPrefab;

        private readonly Dictionary<CharacterStat, CharacterStatView> _statViews = new();

        private IPlayerPopupModel _viewModel;
        private PopupManager _popupManager;

        [Inject]
        private void Construct(IPlayerPopupModel viewModel, PopupManager popupManager)
        {
            _viewModel = viewModel;
            _popupManager = popupManager;
        }
        
        public override void Show()
        {
            _viewModel.UpgradeIcon += OnUpgradeIcon;
            _viewModel.UpgradeName += OnUpgradeName;
            _viewModel.UpgradeDescription += OnUpgradeDescription;
            _viewModel.UpgradeLevel += OnUpgradeLevel;
            _viewModel.UpgradeExperience += OnUpgradeExperience;
            _viewModel.OnCanLevelUp += OnCanLevelUp;
            _viewModel.StatAdded += OnStatAdded;
            _viewModel.StatRemoved += OnStatRemoved;
            
            OnUpgradeIcon(_viewModel.GetIcon);
            OnUpgradeName(_viewModel.GetName);
            OnUpgradeDescription(_viewModel.GetDescription);
            OnCanLevelUp(_viewModel.CanLevelUp);

            foreach (var stat in _viewModel.GetStats) 
                AddStat(stat);

            _levelUpButton.onClick.AddListener(OnLevelUpClicked);
            _closeButton.onClick.AddListener(OnCloseClicked);
            
            OnStateChanged();
        }

        public override void Hide()
        {
            _viewModel.UpgradeIcon -= OnUpgradeIcon;
            _viewModel.UpgradeName -= OnUpgradeName;
            _viewModel.UpgradeDescription -= OnUpgradeDescription;
            _viewModel.UpgradeLevel -= OnUpgradeLevel;
            _viewModel.UpgradeExperience -= OnUpgradeExperience;
            _viewModel.OnCanLevelUp -= OnCanLevelUp;
            _viewModel.StatAdded -= OnStatAdded;
            _viewModel.StatRemoved -= OnStatRemoved;
            
            _levelUpButton.onClick.RemoveAllListeners();
            _closeButton.onClick.RemoveAllListeners();

            foreach (var stat in _statViews) 
                Destroy(_statViews[stat.Key].gameObject);
            
            _statViews.Clear();
            _popupManager.Hide(PopupType.PlayerPopup);
        }

        private void AddStat(CharacterStat stat)
        {
            var statView = Instantiate(_statPrefab, _statContainer);
            statView.Init(stat);
            _statViews.Add(stat, statView);
        }

        private void OnStatAdded(CharacterStat stat)
        {
            AddStat(stat);
        }

        private void OnStatRemoved(CharacterStat stat)
        {
            Destroy(_statViews[stat].gameObject);
            _statViews.Remove(stat);
        }

        private void OnCanLevelUp(bool can) => 
            _levelUpButton.interactable = can;

        private void OnUpgradeIcon(Sprite icon) => 
            _icon.sprite = icon;
        
        private void OnUpgradeName(string text) => 
            _nameLabel.text = text;

        private void OnUpgradeDescription(string text) => 
            _descriptionLabel.text = text;
        
        private void OnUpgradeLevel(string text) => 
            _levelLabel.text = text;

        private void OnUpgradeExperience(string progress, float maxExp, float currentExp)
        {
            _levelProgressLabel.text = progress;
            _levelProgressSlider.maxValue = maxExp;
            _levelProgressSlider.value = currentExp;
        }
        
        private void OnStateChanged()
        {
            OnUpgradeLevel(_viewModel.GetLevel);
            OnUpgradeExperience(_viewModel.GetProgress, _viewModel.GetMaxExp, _viewModel.GetCurrentExp);
            
            print(_viewModel.GetCurrentExp);
        }
        
        private void OnLevelUpClicked() => 
            _viewModel.LevelUp();

        private void OnCloseClicked() => 
            Hide();
    }
}