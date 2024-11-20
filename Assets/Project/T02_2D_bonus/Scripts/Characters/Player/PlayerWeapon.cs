using UnityEngine;
using T02;
using System.Collections.Generic;

namespace T02 {

    public class PlayerWeapon : MonoBehaviour {

        [SerializeField] private T02.PlayerBonuses _playerBonuses;

        [SerializeField] private T02.GameInput _gameInput;
        [SerializeField] private PoolObjects _poolObjects;
        [SerializeField] private Transform _weapon;
        [SerializeField] private float _bulletSpeed;
        private float _defaultDamage = 5f;


        private void OnEnable() {

            _gameInput.OnShotAction += Shot;

        }

        private void Start() {
            _playerBonuses.SetBaseDamage(_defaultDamage);
        }

        private void Shot() {

            GameObject bullet = _poolObjects.CreateObject(_weapon.position, Quaternion.identity);
            Vector3 shootDir = (UIManager.GetMouseWorldPosition() - _weapon.position).normalized;
            float currentDamage = _playerBonuses.GetModifiedDamage();
            bullet.GetComponent<Bullet>().Setup(shootDir, _bulletSpeed, currentDamage);
        
        }

        private void OnDisable() {

            _gameInput.OnShotAction -= Shot;

        }
    }
}
