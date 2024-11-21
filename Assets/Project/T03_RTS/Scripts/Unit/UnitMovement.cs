using UnityEngine;
using UnityEngine.AI;

namespace T03 {

    public class UnitMovement : MonoBehaviour {

        private NavMeshAgent _nmAgent;
        [SerializeField] LayerMask _ground;

        private void Start() {

            _nmAgent = GetComponent<NavMeshAgent>();

        }


        private void Update() {

            Move();

        }

        private void Move() {

            if (Input.GetMouseButtonDown(0)) {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, _ground)) {

                    _nmAgent.SetDestination(hit.point);

                }

            }

        }
    }
}
