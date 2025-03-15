using System.Collections;
using Entities;
using Game.GameEngine.Mechanics.Money.Scripts;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class ProductPoint : MonoEntityStd
    {
        [SerializeField]
        private int productPrice = 100;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) && entity.TryGet(out IComponent_SpendMoney component))
            {
                component.SpendMoney(this.productPrice);
                Debug.Log("BUY PRODUCTS");
                this.StartCoroutine(this.Wait());
            }
        }

        private IEnumerator Wait()
        {
            this.GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(1);
            this.GetComponent<Collider>().enabled = true;
        }
    }
}