// using Entities;
// using Game.GameEngine.Mechanics;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace Lessons.AI.Architecture
// {
//     public sealed class MeleeCombatTask : Task
//     {
//         [SerializeField]
//         private MonoEntity unit;
//
//         [SerializeField]
//         private MonoEntity target;
//
//         [Button]
//         public void SetUnit(MonoEntity unit)
//         {
//             this.unit = unit;
//         }
//
//         [Button]
//         public void SetTarget(MonoEntity target)
//         {
//             this.target = target;
//         }
//
//         protected override void Do()
//         {
//             unit.Get<IComponent_MeleeCombat>().OnCombatStopped += this.OnCombatFinished;
//             unit.Get<IComponent_MeleeCombat>().StartCombat(new CombatOperation(this.target));
//         }
//
//         protected override void OnCancel()
//         {
//             unit.Get<IComponent_MeleeCombat>().OnCombatStopped -= this.OnCombatFinished;
//             unit.Get<IComponent_MeleeCombat>().StopCombat();
//         }
//
//         private void OnCombatFinished(CombatOperation operation)
//         {
//             unit.Get<IComponent_MeleeCombat>().OnCombatStopped -= this.OnCombatFinished;
//
//             bool success = operation.targetDestroyed;
//             Debug.Log($"IS COMBAT SUCCESSFUL {success}");
//             this.Return(success);
//         }
//     }
// }