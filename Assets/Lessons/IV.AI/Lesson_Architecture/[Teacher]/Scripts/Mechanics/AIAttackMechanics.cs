// using AIModule;
// using Entities;
// using Game.GameEngine.Mechanics;
// using UnityEngine;
//
// namespace Lessons.AI.Architecture
// {
//     [CreateAssetMenu(
//         fileName = "AIAttackMechanics",
//         menuName = "Lessons/AI/New AIAttackMechanics"
//     )]
//     public sealed class AIAttackMechanics : AIMechanics
//     {
//         [SerializeField, BlackboardKey]
//         private ushort attackEnabled;
//
//         [SerializeField, BlackboardKey]
//         private ushort attackDistance;
//
//         [SerializeField, BlackboardKey]
//         private ushort character;
//
//         [SerializeField, BlackboardKey]
//         private ushort target;
//
//         public override void OnUpdate(IBlackboard blackboard, float deltaTime)
//         {
//             if (!blackboard.TryGetBool(this.attackEnabled, out bool attackEnabled) ||
//                 !blackboard.TryGetFloat(this.attackDistance, out float attackDistance) ||
//                 !blackboard.TryGetObject(this.character, out IEntity character) ||
//                 !blackboard.TryGetObject(this.target, out IEntity target))
//             {
//                 return;
//             }
//
//             if (!attackEnabled)
//             {
//                 return;
//             }
//
//             if (!target.TryGet(out IComponent_IsAlive aliveComponent) ||
//                 !aliveComponent.IsAlive)
//             {
//                 return;
//             }
//
//             if (!character.TryGet(out IComponent_GetPosition characterTransform) ||
//                 !target.TryGet(out IComponent_GetPosition targetTransform))
//             {
//                 return;
//             }
//             
//             Vector3 currentPosition = characterTransform.Position;
//             Vector3 targetPosition = targetTransform.Position;
//             Vector3 distanceVector = targetPosition - currentPosition;
//             distanceVector.y = 0;
//             
//             if (distanceVector.sqrMagnitude <= attackDistance * attackDistance)
//             {
//                 if (character.TryGet(out IComponent_Combat combatComponent) && !combatComponent.IsCombat)
//                 {
//                     combatComponent.StartCombat(new CombatOperation(target));
//                 }
//             }
//             else
//             {
//                 if (character.TryGet(out IComponent_Combat combatComponent) && combatComponent.IsCombat)
//                 {
//                     combatComponent.StopCombat();
//                 }
//
//                 if (character.TryGet(out IComponent_MoveInDirection moveComponent))
//                 {
//                     moveComponent.Move(distanceVector.normalized);
//                 }
//             }
//         }
//     }
// }