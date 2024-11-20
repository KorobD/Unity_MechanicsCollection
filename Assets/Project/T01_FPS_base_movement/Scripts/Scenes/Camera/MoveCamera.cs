using UnityEngine;


namespace T01 {
    public class MoveCamera : MonoBehaviour {

        [SerializeField] Transform _cameraPos;

        void Update() {

            transform.position = _cameraPos.position;

        }
    }
}
