using UnityEngine;
using T01;


namespace T01 {
    public class PlayerMovement : MonoBehaviour {

        [Header("Input System")]
        [SerializeField] private T01.GameInput _gameInput;

        [Header("Movement")]
        [SerializeField] private int _moveSpeed = 5;
        [SerializeField] private float _groundDrag = 5;

        [Header("Jump")]
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpCooldown;
        [SerializeField] private float _airMultiplier;
        private bool _readyToJump;

        [Header("Ground Check")]
        [SerializeField] private float _playerHeight;
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private Transform _groundCheck;
        private float _groundDistance = 0.4f;
        private bool _grounded;

        [SerializeField] private Transform _orientation;
        private Rigidbody _rb;


        private void Awake() {
            _readyToJump = true;
        }

        private void OnEnable() {

            _gameInput.OnJumpAction += Jump;

        }

        private void Start() {

            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;

        }

        private void Update() {

            CheckGround(_groundDrag);
            SpeedControl(_moveSpeed);

        }

        private void FixedUpdate() {

            Move(_moveSpeed);

        }
        private void Move(int moveSpeed) {

            Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
            Vector3 moveDir = _orientation.forward * inputVector.y + _orientation.right * inputVector.x;
            if (_grounded) {

                _rb.AddForce(moveDir * moveSpeed * 10f, ForceMode.Force);

            } else if(!_grounded) {

                _rb.AddForce(moveDir * moveSpeed * 10f * _airMultiplier, ForceMode.Force);

            }

        }

        private void Jump() {
            Debug.Log("jump");
            if (_readyToJump && _grounded) {

                _readyToJump = false;
                _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.z);
                _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);

                Invoke(nameof(ResetJump), _jumpCooldown);

            }

        }

        private void ResetJump() {

            _readyToJump = true;

        }

        private void SpeedControl(int moveSpeed) {

            Vector3 flatVel = new Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.z);

            if (flatVel.magnitude > moveSpeed) {

                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                _rb.linearVelocity = new Vector3(limitedVel.x, _rb.linearVelocity.y, limitedVel.z);

            }

        }

        private void CheckGround(float groundDrag) {

            _grounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _whatIsGround);

            if (_grounded) {

                _rb.linearDamping = groundDrag;

            } else {

                _rb.linearDamping = 0;

            }

        }

        private void OnDisable() {
            
            _gameInput.OnJumpAction -= Jump;

        }

    }
}
