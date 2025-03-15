using AIModule;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    [CreateAssetMenu(
        fileName = "AIAttackOrPatrolMechanics",
        menuName = "Lessons/AI/New AIAttackOrPatrolMechanics"
    )]
    public sealed class AIAttackOrPatrolMechanics : AIMechanics
    {
        [SerializeField, BlackboardKey] private ushort target;
        [SerializeField, BlackboardKey] private ushort attackEnabled;
        [SerializeField, BlackboardKey] private ushort patrolEnabled;

        public override void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            bool hasTarget = blackboard.HasKey(this.target);
            blackboard.SetBool(this.attackEnabled, hasTarget);
            blackboard.SetBool(this.patrolEnabled, !hasTarget);
        }
    }
}



