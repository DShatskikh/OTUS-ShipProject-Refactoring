// using System.Collections;
// using Entities;
// using Game.GameEngine.Mechanics;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace Lessons.AI.Architecture
// {
//     public sealed class MoveToPositionTask : Task
//     {
//         [SerializeField]
//         private MonoEntity unit;
//
//         [SerializeField]
//         private Vector3 targetPosition;
//
//         [SerializeField]
//         private float stoppingDistance;
//
//         private Coroutine moveCoroutine;
//         
//         [Button]
//         public void SetTargetPosition(Transform point)
//         {
//             this.targetPosition = point.position;
//         }
//
//         public void SetTargetPosition(Vector3 targetPosition)
//         {
//             this.targetPosition = targetPosition;
//         }
//
//         [Button]
//         public void SetStoppingDistance(float stoppingDistance)
//         {
//             this.stoppingDistance = stoppingDistance;
//         }
//
//         [Button]
//         public void SetUnit(MonoEntity unit)
//         {
//             this.unit = unit;
//         }
//
//         protected override void Do()
//         {
//             this.moveCoroutine = this.StartCoroutine(this.MoveRoutine());
//         }
//
//         protected override void OnCancel()
//         {
//             if (this.moveCoroutine != null)
//             {
//                 this.StopCoroutine(this.moveCoroutine);
//                 this.moveCoroutine = null;
//             }
//         }
//
//         private IEnumerator MoveRoutine()
//         {
//             IComponent_GetPosition posiitonComponent = this.unit.Get<IComponent_GetPosition>();
//             IComponent_MoveInDirection moveComponent = this.unit.Get<IComponent_MoveInDirection>();
//             var period = new WaitForFixedUpdate();
//
//             while (true)
//             {
//                 Vector3 distanceVector = this.targetPosition - posiitonComponent.Position;
//                 float distance = distanceVector.magnitude;
//                 
//                 if (distance <= this.stoppingDistance)
//                 {
//                     break;
//                 }
//
//                 Vector3 direction = distanceVector.normalized;
//                 moveComponent.Move(direction);
//
//                 yield return period;
//             }
//
//             yield return period; //Костыль...
//             
//             this.moveCoroutine = null;
//             this.Return(true);
//         }
//     }
// }