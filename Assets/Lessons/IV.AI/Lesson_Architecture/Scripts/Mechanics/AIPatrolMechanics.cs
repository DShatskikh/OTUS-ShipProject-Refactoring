using AIModule;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    [CreateAssetMenu(
        fileName = "AIPatrolMechanics",
        menuName = "Lessons/AI/New AIPatrolMechanics"
    )]
    public sealed class AIPatrolMechanics : AIMechanics
    {
        [SerializeField, BlackboardKey]
        private ushort character;

        [SerializeField, BlackboardKey]
        private ushort patrolEnabled;

        [SerializeField, BlackboardKey]
        private ushort patrolPoints;

        [SerializeField, BlackboardKey]
        private ushort patrolIndex;

        [SerializeField, BlackboardKey]
        private ushort stoppingDistance;

        public override void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            if (!blackboard.TryGetObject(this.character, out IEntity character) ||
                !blackboard.TryGetBool(this.patrolEnabled, out bool patrolEnabled) ||
                !blackboard.TryGetObject(this.patrolPoints, out Transform[] patrolPoints) ||
                !blackboard.TryGetInt(this.patrolIndex, out int patrolIndex) ||
                !blackboard.TryGetFloat(this.stoppingDistance, out float stoppingDistance))
            {
                return;
            }

            if (!patrolEnabled)
            {
                return;
            }

            if (!character.TryGet(out IComponent_GetPosition characterTransform))
            {
                return;
            }

            Vector3 characterPosition = characterTransform.Position;
            Vector3 targetPosition = patrolPoints[patrolIndex].position;
            Vector3 distanceVector = targetPosition - characterPosition;
            distanceVector.y = 0;

            if (distanceVector.sqrMagnitude <= stoppingDistance * stoppingDistance)
            {
                patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
                blackboard.SetInt(this.patrolIndex, patrolIndex);
            }
            else
            {
                if (character.TryGet(out IComponent_MoveInDirection moveComponent))
                {
                    moveComponent.Move(distanceVector.normalized);
                }
            }
        }
    }
}