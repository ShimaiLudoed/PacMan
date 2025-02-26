using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private GameInputActions _inputActions;

        private void Start()
        {
            _inputActions = new GameInputActions();
            Bind();
        }

        private void OnDisable()
        {
            Expose();
        }

        private void Update()
        {
            //Debug.Log(_inputActions.Game.Move.ReadValue<Vector2>());
        }

        private void Bind()
        {
            _inputActions.Game.Move.performed += OnMoveInputStarted;
            _inputActions.Game.Move.canceled += OnMoveInputCanceled;

            _inputActions.Enable();
        }

        private void OnMoveInputStarted(InputAction.CallbackContext context)
        {
            Vector2 moveDirection = context.ReadValue<Vector2>();
            Debug.Log(moveDirection);

        }

        private void OnMoveInputCanceled(InputAction.CallbackContext context)
        {
            //stop movement or etc
            Debug.Log("MoveInputCanceled");
        }

        private void Expose()
        {
            _inputActions.Disable();

            _inputActions.Game.Move.performed -= OnMoveInputStarted;
            _inputActions.Game.Move.canceled -= OnMoveInputCanceled;
        }
    }
}
