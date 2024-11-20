using UnityEngine;


namespace T02 {
    public class PlayerMovement : MonoBehaviour {

        [SerializeField] T02.GameInput _gameInput;

        [Header("Movement")]
        [SerializeField] private float _moveSpeed = 5f;


        private void Awake() {
            
        }

        private void Start() {
        
        }

        private void Update() {

            Move();

        }

        private void Move() {

            Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
            transform.position += moveDir * _moveSpeed * Time.deltaTime;
        
        }
    }
}
