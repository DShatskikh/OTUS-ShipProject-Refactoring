// using System;
// using Lessons.AI.Architecture;
// using UnityEngine;
// using Entities;
//
// namespace Lessons.AI
// {
//     public sealed class AgentInstaller : MonoBehaviour
//     {
//         [SerializeField]
//         private MonoEntity unit;
//
//         [SerializeField]
//         private AttackAgent attackAgent;
//
//         private void Awake()
//         {
//             this.attackAgent.SetUnit(this.unit);
//             this.attackAgent.SetStoppingDistance(1);
//         }
//     }
// }