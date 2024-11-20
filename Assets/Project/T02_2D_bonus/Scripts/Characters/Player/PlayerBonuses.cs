using System.Collections.Generic;
using T02;
using UnityEngine;

namespace T02 {
    public class PlayerBonuses : MonoBehaviour {

        private List<T02.IModifierDamage> _activeModifiers = new();
        private float _baseDamage;
        private float _currentDamage;
        public float BaseDamage => _baseDamage;

        public void SetBaseDamage(float baseDamage) {
            _baseDamage = baseDamage;
            _currentDamage = baseDamage;
            RecalculateDamage();
        }

        public void AddModifier(IModifierDamage modifier) {
            if (!_activeModifiers.Contains(modifier)) {
                Debug.Log("Modifier added: " + modifier.GetType().Name);
                _activeModifiers.Add(modifier);
                RecalculateDamage();
            } else {
                Debug.LogWarning("Modifier already exists: " + modifier.GetType().Name);
            }
        }

        public void RemoveModifier(IModifierDamage modifier) {

            if (_activeModifiers.Contains(modifier)) {
                Debug.Log("Modifier removed: " + modifier.GetType().Name);
                _activeModifiers.Remove(modifier);
                RecalculateDamage();
            } else {
                Debug.LogWarning("Modifier not found: " + modifier.GetType().Name);
            }
        }

        public void RecalculateDamage() {

            _currentDamage = _baseDamage; 

            foreach (var modifier in _activeModifiers) {
                _currentDamage = modifier.Apply(_currentDamage); 
            }
        }

        public float GetModifiedDamage() {

            return _currentDamage;
        }
    }
}

