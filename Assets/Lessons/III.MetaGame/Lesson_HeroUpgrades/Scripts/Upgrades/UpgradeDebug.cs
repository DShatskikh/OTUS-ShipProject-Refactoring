using System;
using System.Collections.Generic;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.III.MetaGame.Lesson_HeroUpgrades
{
    public class UpgradeDebug : MonoBehaviour, IGameElementGroup
    {
        public UpgradeConfig UpgradeConfig;
        private Upgrade _upgrade;

        public void Awake()
        {
            _upgrade = UpgradeConfig.Create();
        }

        [Button]
        public void LevelUp()
        {
            _upgrade.LevelUp();
        }

        public IEnumerable<IGameElement> GetElements()
        {
            yield return _upgrade as IGameElement;
        }
    }
}