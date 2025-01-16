using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class GameInstaller : MonoInstaller
    {
        [Header("PopupManager")]
        [SerializeField]
        private Transform _uiContainer;
        
        [SerializeField]
        private SerializablePair<PopupType, BasePopup>[] _pairs;
        
        [Header("PlayerPopup")]
        [SerializeField]
        private string _name;

        [SerializeField]
        private string _description;
        
        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private SerializablePair<string, int>[] _characterStats;
        
        public override void InstallBindings()
        {
            Container.Bind<UserInfo>().AsSingle().WithArguments(_name, _description, _icon);
            
            var stats = new List<CharacterStat>();

            foreach (var stat in _characterStats) 
                stats.Add(new CharacterStat(stat.Key, stat.Value));
            
            Container.Bind<CharacterInfo>().AsSingle().WithArguments(stats);
            Container.Bind<PlayerLevel>().AsSingle();
            Container.Bind<IPlayerPopupModel>().To<PlayerPopupModel>().AsSingle();
            Container.Bind<PopupManager>().AsSingle().WithArguments(_pairs, _uiContainer);
        }
    }
}