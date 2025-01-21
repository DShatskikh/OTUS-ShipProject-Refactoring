using System.Collections.Generic;
using TMPro;
using UniRx;
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

        [Inject]
        private void Construct(IPlayerPopupModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public override void Show()
        {
            _viewModel.Icon.SubscribeToImage(_icon).AddTo(this);
            _viewModel.Name.SubscribeToText(_nameLabel).AddTo(this);
            _viewModel.Description.SubscribeToText(_descriptionLabel).AddTo(this);
            _viewModel.Level.SubscribeToText(_levelLabel).AddTo(this);
            _viewModel.CanLevelUp.SubscribeToInteractable(_levelUpButton).AddTo(this);
            _viewModel.LevelProgress.SubscribeToText(_levelProgressLabel).AddTo(this);
            _viewModel.MaxExpProgress.Subscribe(maxProgress => _levelProgressSlider.maxValue = maxProgress).AddTo(this);
            _viewModel.CurrentExpProgress.Subscribe(currentProgress => _levelProgressSlider.value = currentProgress).AddTo(this);
            _viewModel.Stats.ObserveAdd().Subscribe(stat => Create(stat.Value)).AddTo(this);
            
            _viewModel.Stats.ObserveRemove().Subscribe(stat =>
            {
                Destroy(_statViews[stat.Value].gameObject);
                _statViews.Remove(stat.Value);
            }).AddTo(this);

            foreach (var stat in _viewModel.Stats) 
                Create(stat);

            _levelUpButton.onClick.AddListener(OnLevelUpClicked);
            _closeButton.onClick.AddListener(OnCloseClicked);
        }

        public override void Hide()
        {
            _levelUpButton.onClick.RemoveAllListeners();
            _closeButton.onClick.RemoveAllListeners();

            foreach (var stat in _statViews) 
                Destroy(_statViews[stat.Key].gameObject);
            
            _statViews.Clear();
        }
        
        private void OnLevelUpClicked() => 
            _viewModel.LevelUp();

        private void OnCloseClicked() => 
            _viewModel.Hide();

        private void Create(CharacterStat stat)
        {
            var statView = Instantiate(_statPrefab, _statContainer);
            statView.Init(stat);
            _statViews.Add(stat, statView);
        }
    }
}