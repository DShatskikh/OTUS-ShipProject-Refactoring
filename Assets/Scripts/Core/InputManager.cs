using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        private CharacterController _characterController;
        private float _horizontalDirection;

        private void Awake()
        {
            _characterController = ServiceLocator.Get<CharacterController>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
                _characterController.ReadyFire();

            if (Input.GetKeyUp(KeyCode.Space)) 
                _characterController.Fire(Vector3.up);

            _horizontalDirection = Input.GetAxisRaw("Horizontal");
        }
        
        private void FixedUpdate()
        {
            _characterController.Move(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}