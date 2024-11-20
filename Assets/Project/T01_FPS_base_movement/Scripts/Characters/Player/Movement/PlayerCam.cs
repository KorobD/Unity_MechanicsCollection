using UnityEngine;
using T01;

namespace T01 {
    public class PlayerCam : MonoBehaviour {

        [Header("Input System")]
        [SerializeField] private T01.GameInput _gameInput;

        [Header("Look Setting")]
        [SerializeField] private float _sensitivity = 50;

        [SerializeField] private Transform _orientation;

        private bool _menuIsOpen = false;
        private float _xRot = 0;
        private float _yRot = 0;

        private void Awake() {


        }

        private void Update() {

            if (!_menuIsOpen) {
                Look(_sensitivity);
            }

        }

        private void Look(float sensitivity) {

            Vector2 mouseLook = _gameInput.GetLook();
            float mouseX = mouseLook.x * sensitivity * Time.deltaTime;
            float mouseY = mouseLook.y * sensitivity * Time.deltaTime;

            _yRot += mouseX;
            _xRot -= mouseY;
            _xRot = Mathf.Clamp(_xRot, -90f, 90f);

            transform.rotation = Quaternion.Euler(_xRot, _yRot, 0);
            _orientation.rotation = Quaternion.Euler(0, _yRot, 0);

        }

        private void CheckMenu() {

            _menuIsOpen = !_menuIsOpen;

        }
    }
}
