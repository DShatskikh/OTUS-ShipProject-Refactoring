using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Game
{
    public sealed class ArrowTriggerComponent : MonoBehaviour
    {
        [SerializeField]
        private Entity _entity;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Entity target))
            {
                #region 1

                // EcsWorld ecsWorld = EcsStartup.Instance.GetWorld(EcsWorlds.EVENTS);
                // int newEntity = ecsWorld.NewEntity();
                //
                // EcsPool<CollisionEnterRequest> ecsPool = ecsWorld.GetPool<CollisionEnterRequest>();
                // ecsPool.Add(newEntity) = new CollisionEnterRequest();

                #endregion

                #region 2

                if (!_entity.TryGetData<UnitCommand>(out var command) || !target.TryGetData<UnitCommand>(out var targetCommand))
                    return;

                if (command.Value == targetCommand.Value)
                    return;
                
                Debug.Log($"ON TRIGGER ENTER {target.gameObject.name} ID {target.Id}", this);
                
                EcsStartup.Instance.CreateEntity(EcsWorlds.EVENTS)
                    .Add(new CollisionEnterRequest() { Source = _entity, Target = target })
                    .Add(new ArrowTag());

                #endregion
            }
        }
    }
}