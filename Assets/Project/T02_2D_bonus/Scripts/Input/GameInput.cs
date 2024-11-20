using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace T02 {
    public class GameInput : MonoBehaviour {

        private GameInputActions _gameInputActions;

        public Action OnMenuAction;
        public Action OnShotAction;

        private void Awake() {
            
            _gameInputActions = new GameInputActions();

        }

        private void OnEnable() {
            
            _gameInputActions.T02_Player.Enable();
            _gameInputActions.T02_Player.ShowMenu.performed += ShowMenu_performed;
            _gameInputActions.T02_Player.Shot.performed += Shot_performed;

        }

        public Vector2 GetMovementVectorNormalized() {

            Vector3 inputVector = _gameInputActions.T02_Player.Move.ReadValue<Vector2>();
            return inputVector;
        
        }

        public void ShowMenu_performed(InputAction.CallbackContext context) {
            
            OnMenuAction?.Invoke();

        }

        public void Shot_performed(InputAction.CallbackContext context) {
        
            OnShotAction?.Invoke();
        
        }


        private void OnDisable() {

            _gameInputActions.T02_Player.Disable();
            _gameInputActions.T02_Player.ShowMenu.performed -= ShowMenu_performed;
            _gameInputActions.T02_Player.Shot.performed -= Shot_performed;

        }

    }
}
