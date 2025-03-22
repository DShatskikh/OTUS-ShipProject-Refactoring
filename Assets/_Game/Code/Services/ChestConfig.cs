using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Chest", menuName = "Config/Chest", order = 200)]
    public class ChestConfig : ScriptableObject
    {
        [SerializeField]
        private string _id;
        
        [SerializeField]
        private string _name;

        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private double _timeSecond;

        [SerializeReference]
        private IOpenChestAction _openAction;
        
        public string GetID => _id;
        public string GetName => _name;
        public Sprite GetIcon => _icon;
        public double GetTimeSecond => _timeSecond;
        public IOpenChestAction GetOpenAction => _openAction;
    }
}