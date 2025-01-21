using System;
using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public interface IPlayerPopupModel
    {
        IReadOnlyReactiveProperty<Sprite> Icon { get; }
        IReadOnlyReactiveProperty<string> Name { get; }
        IReadOnlyReactiveProperty<string> Description { get; }
        IReadOnlyReactiveProperty<string> Level { get; }
        IReadOnlyReactiveProperty<bool> CanLevelUp { get; }
        IReadOnlyReactiveProperty<string> LevelProgress { get; }
        IReadOnlyReactiveProperty<float> MaxExpProgress { get; }
        IReadOnlyReactiveProperty<float> CurrentExpProgress { get; }
        IReadOnlyReactiveCollection<CharacterStat> Stats { get; }
        void LevelUp();
        void Hide();
    }
}