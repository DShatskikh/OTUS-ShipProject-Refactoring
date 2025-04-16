using UnityEngine;

namespace _Project.Code
{
    public sealed class BotInput : MonoBehaviour
    {
        [SerializeField]
        private Steve _steve;

        [SerializeField]
        private RangeDetector _rangeDetector;
        
        private void Update()
        {
            var direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            
            if (direction.magnitude > 0)
                _steve.MoveTo(transform.position - direction);
            else
                _steve.StopMove();

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_rangeDetector.TryUpdateDetector(out CraftTable craftTable))
                    _steve.TryDropToCraftTable(craftTable);
                
                if (_rangeDetector.TryUpdateDetector(out Ore ore))
                    _steve.TryMining(ore);
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                _steve.StopMining();
                _steve.StopDropToCraftTable();
            }
        }
    }
}