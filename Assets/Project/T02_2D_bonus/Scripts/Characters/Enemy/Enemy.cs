using UnityEngine;


namespace T02 {

    public class Enemy : MonoBehaviour {

        public void OnTakenDamage(float damage) {

            UIDamagePopup.Create(transform.position, damage);

        }

    }

}
