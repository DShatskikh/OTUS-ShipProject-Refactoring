using AIModule;
using Entities;
using UnityEngine;

namespace Lessons.AI.Architecture.Sensors
{
    public sealed class AITargetTrigger : MonoBehaviour
    {
        [SerializeField]
        private MonoEntity[] enemies;

        private void OnTriggerEnter(Collider col)
        {
            foreach (var enemy in this.enemies)
            {
                Blackboard blackboard = enemy.Get<Blackboard>();
                if (!blackboard.HasKey(BlackboardAPI.Target) && col.TryGetComponent(out IEntity obj))
                {
                    blackboard.SetObject(BlackboardAPI.Target, obj);
                }
                
            }
            
          
        }

        private void OnTriggerExit(Collider col)
        {
            foreach (var enemy in this.enemies)
            {
                Blackboard blackboard = enemy.Get<Blackboard>();
                if (blackboard.TryGetObject(BlackboardAPI.Target , out IEntity target) &&
                    col.TryGetComponent(out IEntity obj) && target == obj)
                {
                    blackboard.DeleteObject(BlackboardAPI.Target);
                }
            }
            
           
        }
    }
}