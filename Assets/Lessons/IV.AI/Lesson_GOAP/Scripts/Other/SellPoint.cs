using Entities;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics.Money.Scripts;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class SellPoint : MonoEntityStd
    {
        [SerializeField]
        private int pricePerStone = 10;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) &&
                entity.TryGet(out IComponent_ResourceSource resourceSource) && 
                entity.TryGet(out IComponent_EarnMoney moneyComponent))
            {
                int stone = resourceSource.GetResources(ResourceType.STONE);
                resourceSource.Clear();
                
                Debug.Log("SELL RESOURCES");
                moneyComponent.EarnMoney(this.pricePerStone * stone);
            }
        }
    }
}