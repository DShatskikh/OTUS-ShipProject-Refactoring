// using AIModule;
// using Entities;
// using Game.GameEngine.Mechanics;
// using UnityEngine;
//
// namespace Lessons.AI.Architecture
// {
//     [CreateAssetMenu(
//         fileName = "AIPatrolMechanics",
//         menuName = "Lessons/AI/New AIPatrolMechanics"
//     )]
//     public sealed class AIPatrolMechanics : AIMechanics
//     {
//         [SerializeField, BlackboardKey]
//         private ushort patrolEnabled;
//
//         [SerializeField, BlackboardKey]
//         private ushort patrolPoints;
//
//         [SerializeField, BlackboardKey]
//         private ushort patrolIndex;
//
//         [SerializeField, BlackboardKey]
//         private ushort stoppingDistance;
//
//         [SerializeField, BlackboardKey]
//         private ushort character;
//
//         public override void OnUpdate(IBlackboard blackboard, float deltaTime)
//         {
//             if (!blackboard.TryGetBool(this.patrolEnabled, out bool patrolEnabled) ||
//                 !blackboard.TryGetObject(this.patrolPoints, out Transform[] patrolPoints) ||
//                 !blackboard.TryGetInt(this.patrolIndex, out int patrolIndex) ||
//                 !blackboard.TryGetFloat(this.stoppingDistance, out float stoppingDistance) ||
//                 !blackboard.TryGetObject(this.character, out IEntity character))
//             {
//                 return;
//             }
//
//             if (!patrolEnabled)
//             {
//                 return;
//             }
//
//             if (!character.TryGet(out IComponent_GetPosition positionComponent) ||
//                 !character.TryGet(out IComponent_MoveInDirection moveComponent))
//             {
//                 return;
//             }
//
//             Vector3 currentPosition = positionComponent.Position;
//             Vector3 targetPosition = patrolPoints[patrolIndex].position;
//             Vector3 distanceVector = targetPosition - currentPosition;
//             distanceVector.y = 0;
//
//             if (distanceVector.sqrMagnitude <= stoppingDistance * stoppingDistance)
//             {
//                 patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
//                 blackboard.SetInt(this.patrolIndex, patrolIndex);
//             }
//             else
//             {
//                 moveComponent.Move(distanceVector.normalized);
//             }
//         }
//     }
// }