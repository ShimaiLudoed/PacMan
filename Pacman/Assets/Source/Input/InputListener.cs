using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputListener : MonoBehaviour, IInputHandler
    {
        private Vector2 _currentDirection;
        private GameInputActions _inputActions;
        public event Action<Vector2> OnMove;
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
            Debug.Log(_inputActions.Game.Move.ReadValue<Vector2>());
        }

        private void Bind()
        {
            _inputActions.Game.Move.performed += OnMoveInputStarted;
            _inputActions.Game.Move.canceled += OnMoveInputCanceled;

            _inputActions.Enable();
        }

        private void OnMoveInputStarted(InputAction.CallbackContext context)
        {
            Vector2 moveDirection = context.ReadValue<Vector2>().normalized;
            
            if (moveDirection.x != 0)
            {
                _currentDirection = new Vector2(moveDirection.x, 0f).normalized; 
            }
            else if (moveDirection.y != 0)
            {
                _currentDirection = new Vector2(0f, moveDirection.y).normalized;
            }
        
            OnMove?.Invoke(_currentDirection);
        }

        private void OnMoveInputCanceled(InputAction.CallbackContext context)
        {
            Vector2 stop= Vector2.zero;
            OnMove?.Invoke(stop);
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
