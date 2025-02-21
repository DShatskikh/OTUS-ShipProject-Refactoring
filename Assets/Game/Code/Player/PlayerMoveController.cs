using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField]
        private SceneEntity _entity;

        [SerializeField]
        private PlayerInput _input;

        private void Start()
        {
            _input.actions["Fire"].started += _ => _entity.GetIsShotPress().Value = true;
            _input.actions["Fire"].canceled += _ => _entity.GetIsShotPress().Value = false;
        }

        private void Update()
        {
            if (!SceneContext.Instance.GetIsPlaying().Value)
                return;
            
            _entity.SetInputDirection(_input.actions["Move"].ReadValue<Vector2>());
            
            float mouseX = Mouse.current.position.x.ReadValue();
            float mouseY = Mouse.current.position.y.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(mouseX, mouseY, 0));

            var mousePosition = ray.GetPoint(11);
            _entity.SetSeePoint(mousePosition);
        }
    }
}