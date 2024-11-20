using UnityEngine;


namespace T02 {

    public class Bullet : PooledObject {

        private Vector3 _shootDir;
        private float _moveSpeed;
        private float _getDamage;
        [SerializeField] private Enemy _enemy;

        private void Update() {
            Move();
        }

        public void Setup(Vector3 shootDir, float moveSpeed, float getDamage) {
        
            this._shootDir = shootDir;
            this._moveSpeed = moveSpeed;
            this._getDamage = getDamage;

            CancelInvoke(nameof(DeactiveBullet));
            Invoke(nameof(DeactiveBullet), 1f);

        }

        private void Move() {

            transform.position += _shootDir * _moveSpeed * Time.deltaTime;
        
        }

        private void DeactiveBullet() {

            this.gameObject.SetActive(false);

        }

        private void OnTriggerEnter2D(Collider2D collision) {

            if (collision.CompareTag("Enemy")) {
                _enemy.OnTakenDamage(_getDamage);
                gameObject.SetActive(false);

            }


        }
    }
}
