using AI.Blackboards;
using AI.Waypoints;
using Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class BlackboardInstaller : MonoBehaviour
    {
        [SerializeField]
        private UnityBlackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [SerializeField]
        private MonoEntity unit;

        [BlackboardKey]
        [SerializeField]
        private string waypointsKey;

        [SerializeField]
        private WaypointsPath waypoints;

        [BlackboardKey]
        [SerializeField]
        private string healingKey;
        
        [SerializeField]
        private HealingPoint healingPoint;

        [BlackboardKey]
        [SerializeField]
        private string marketKey;

        [FormerlySerializedAs("marketPoint")]
        [SerializeField]
        private SellPoint sellPoint;
        
        [BlackboardKey]
        [SerializeField]
        private string beerKey;

        [FormerlySerializedAs("marketPoint")]
        [FormerlySerializedAs("beerPoint")]
        [SerializeField]
        private ProductPoint productPoint;

        [BlackboardKey]
        [SerializeField]
        private string resourceKey;
        
        [SerializeField]
        private MonoEntity resourceObject;

        private void Awake()
        {
            this.blackboard.AddVariable(this.unitKey, this.unit);
            this.blackboard.AddVariable(this.waypointsKey, this.waypoints);
            this.blackboard.AddVariable(this.healingKey, this.healingPoint);
            this.blackboard.AddVariable(this.marketKey, this.sellPoint);
            this.blackboard.AddVariable(this.beerKey, this.productPoint);
            this.blackboard.AddVariable(this.resourceKey, this.resourceObject);
        }
    }
}