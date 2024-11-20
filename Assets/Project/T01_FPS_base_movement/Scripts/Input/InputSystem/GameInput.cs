using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace T01 {
    public class GameInput : MonoBehaviour {

        private GameInputActions _gameInputActions;

        public Action OnJumpAction; 

        private void Awake() {

            _gameInputActions = new GameInputActions();

        }

        private void OnEnable() {

            _gameInputActions.T01_Player.Enable();
            _gameInputActions.T01_Player.Jump.performed += Jump; 

        }

        public Vector2 GetMovementVectorNormalized() {

            Vector2 inputVector = _gameInputActions.T01_Player.Move.ReadValue<Vector2>();
            inputVector = inputVector.normalized;
            return inputVector;

        }

        public Vector2 GetLook() {

            Vector2 mouseLook = _gameInputActions.T01_Player.Look.ReadValue<Vector2>();
            return mouseLook;
        }

        private void Jump(InputAction.CallbackContext context) {

            OnJumpAction?.Invoke();
        }

        private void OnDisable() {

            _gameInputActions.T01_Player.Disable();
            _gameInputActions.T01_Player.Jump.performed -= Jump;

        }
    }
}
