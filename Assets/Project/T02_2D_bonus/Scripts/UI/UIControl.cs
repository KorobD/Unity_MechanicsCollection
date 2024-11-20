using UnityEngine;
using T02;

namespace T02 {
    public class UIControl : MonoBehaviour {

        [Header("Input System")]
        [SerializeField] private T02.GameInput _gameInput;

        [Header("Menus")]
        [SerializeField] private GameObject _toggleMenu;
        private bool _toggleMenuIsVisible = false;


        private void Awake() {

            UIManager.HideMenu(_toggleMenu);

        }

        private void OnEnable() {

            _gameInput.OnMenuAction += ToggleMenu;

        }

        private void OnDisable() {

            _gameInput.OnMenuAction -= ToggleMenu;

        }

        private void ToggleMenu() {
            _toggleMenuIsVisible = !_toggleMenuIsVisible;

            if (_toggleMenuIsVisible) {

                UIManager.ShowMenu(_toggleMenu);

            } else {

                UIManager.HideMenu(_toggleMenu);

            }
        }

    }
}