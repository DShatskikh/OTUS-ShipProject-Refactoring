
using AIModule;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    [CreateAssetMenu(
        fileName = "AITargetSensor",
        menuName = "Lessons/AI/New AITargetSensor"
    )]
    public sealed class AISphereTargetSensor : AIMechanics, IAIGizmos
    {
        private static readonly Collider[] buffer = new Collider[32];

        [SerializeField, BlackboardKey]
        private ushort center;

        [SerializeField, BlackboardKey]
        private ushort radius;

        [SerializeField, BlackboardKey]
        private ushort target;

        [SerializeField]
        private LayerMask layerMask;

        public override void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            if (!blackboard.TryGetObject(this.center, out Transform center) ||
                !blackboard.TryGetFloat(this.radius, out float radius))
            {
                return;
            }

            int count = Physics.OverlapSphereNonAlloc(center.position, radius, buffer, this.layerMask);
            for (var i = 0; i < count; i++)
            {
                Collider collider = buffer[i];

                if (!collider.TryGetComponent(out IEntity obj))
                {
                    continue;
                }

                if (obj.TryGet(out IComponent_IsAlive aliveComponent) && aliveComponent.IsAlive)
                {
                    blackboard.SetObject(this.target, obj);
                    return;
                }
            }

            blackboard.DeleteObject(this.target);
        }

        public void OnGizmos(IBlackboard blackboard)
        {
            if (!blackboard.TryGetObject(this.center, out Transform center) ||
                !blackboard.TryGetFloat(this.radius, out float radius))
            {
                return;
            }

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(center.position, radius);
        }
    }
}

