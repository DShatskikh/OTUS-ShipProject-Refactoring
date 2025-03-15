using Atomic.Entities;
using UnityEngine;

namespace Lessons.Lesson_AtomicFramework
{
    public class MoveController : MonoBehaviour
    {
        // [SerializeField] private Character _character;
        [SerializeField] private SceneEntity _sceneEntity;
        
        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            Move(Vector3.zero);
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.Move(Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.Move(Vector3.back);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.Move(Vector3.right);
            }
        }
        
        private void Move(Vector3 direction)
        {
            _sceneEntity.GetMoveDirection().Value = direction;
            _sceneEntity.GetRotateDirection().Value = direction;
            // _sceneEntity.GetSetMoveDirectionAction().Invoke(direction);
        }
    }
}