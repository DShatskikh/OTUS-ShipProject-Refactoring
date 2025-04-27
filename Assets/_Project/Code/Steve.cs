using System.Collections;
using TMPro;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code
{
    public sealed class Steve : MonoBehaviour
    {
        public SteveInventory Inventory;
        public NavigationMover NavigationMover;
        public Animator Animator;
        public RangeDetector RangeDetector;

        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private TMP_Text _countLabel;
        
        [SerializeField]
        private NavMeshSurface _navMeshSurface;
        
        private Coroutine _miningProcess;
        private Coroutine _dropToCraftTableProcess;
        
        public bool IsMining => _miningProcess != null;
        public bool IsDropToCraftTable => _dropToCraftTableProcess != null;
        public bool IsMove => NavigationMover.GetIsMove;

        private void Start()
        {
            _countLabel.text = $"Руды [{Inventory.GetItems.Count} из 2]";
        }

        private void Update()
        {
            Animator.SetFloat("SpeedMagnitude", IsMove && !NavigationMover.GetIsRotate ? 1 : 0);
        }

        public void MoveTo(Vector3 point)
        {
            StopAllActions();
            NavigationMover.StartMove(point);
        }
        
        public void StopMove()
        {
            NavigationMover.StopMove();
        }
        
        public bool TryMining(Ore ore)
        {
            if (IsMining)
                return false;

            var distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                new Vector3(ore.transform.position.x, 0, ore.transform.position.z));
            
            if (distance / 2 > RangeDetector.GetDetectionRadius)
                return false;

            StopAllActions();
            _miningProcess = StartCoroutine(AwaitMining(ore));
            return true;
        }

        public bool TryDropToCraftTable(CraftTable craftTable)
        {
            if (IsDropToCraftTable)
                return false;
            
            var distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                new Vector3(craftTable.transform.position.x, 0, craftTable.transform.position.z));
            
            if (distance / 2 > RangeDetector.GetDetectionRadius)
                return false;
            
            StopAllActions();
            _dropToCraftTableProcess = StartCoroutine(AwaitDropToCraftTable(craftTable));
            return true;
        }

        public void StopMining()
        {
            if (!IsMining)
                return;
            
            Animator.CrossFade("idle", 0);
            _slider.gameObject.SetActive(false);
            StopCoroutine(_miningProcess);
            _miningProcess = null;
        }
        
        public void StopDropToCraftTable()
        {
            if (!IsDropToCraftTable)
                return;
            
            Animator.CrossFade("idle", 0);
            _slider.gameObject.SetActive(false);
            StopCoroutine(_dropToCraftTableProcess);
            _dropToCraftTableProcess = null;
        }
        
        private IEnumerator AwaitDropToCraftTable(CraftTable craftTable)
        {
            yield return AwaitRotate(craftTable.transform);
            
            var timer = 2f;
            _slider.maxValue = 2f;
            _slider.gameObject.SetActive(true);
            
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                _slider.value = 2 - timer;
                yield return null;
            }
            _slider.gameObject.SetActive(false);
            
            foreach (var item in Inventory.GetItems) 
                craftTable.AddItem(item);

            Inventory.RemoveAllItems();
            _countLabel.gameObject.SetActive(true);
            _countLabel.text = $"Руды [{Inventory.GetItems.Count} из 2]";
            _dropToCraftTableProcess = null;
        }
        
        private IEnumerator AwaitMining(Ore ore)
        {
            yield return AwaitRotate(ore.transform);
            Animator.CrossFade("mining", 0);

            var timer = 2f;
            _slider.maxValue = 2f;
            _slider.gameObject.SetActive(true);
            
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                _slider.value = 2 - timer;
                yield return null;
            }
            
            _slider.gameObject.SetActive(false);
            
            Inventory.Add(ore.Item);
            Destroy(ore.gameObject);
            Animator.CrossFade("idle", 0);
            _countLabel.gameObject.SetActive(true);
            _countLabel.text = $"Руды [{Inventory.GetItems.Count} из 2]";

            yield return null;
            _navMeshSurface.BuildNavMesh();
            
            _miningProcess = null;
        }

        private IEnumerator AwaitRotate(Transform target)
        {
            Vector3 currentWaypoint = target.position;
            Vector3 direction = currentWaypoint - transform.position;
            direction.y = 0;
            
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                
                while (transform.rotation != targetRotation)
                {
                    transform.rotation = Quaternion.RotateTowards(
                        transform.rotation,
                        targetRotation,
                        200 * Time.deltaTime);
                    yield return null;
                }  
            }
        }

        private void StopAllActions()
        {
            StopMove();
            StopMining();
            StopDropToCraftTable();
        }
    }
}