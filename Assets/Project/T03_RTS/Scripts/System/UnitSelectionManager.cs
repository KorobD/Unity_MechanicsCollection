using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace T03 {

    public class UnitSelectionManager : MonoBehaviour {

        public static UnitSelectionManager Instance { get; set; }

        public List<GameObject> allUnitsList = new List<GameObject>();
        public List<GameObject> unitsSelected = new List<GameObject>();

        [SerializeField] LayerMask _clickable;
        [SerializeField] LayerMask _ground;
        public GameObject groundMarker;

        private void Awake() {
            if (Instance != null && Instance != this) {

                Destroy(gameObject);

            } else {

                Instance = this;

            }
        }

        private void Update() {

            if (Input.GetMouseButtonDown(0)) {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, _clickable)) {

                    if (Input.GetKey(KeyCode.LeftShift)) {

                        MultiSelect(hit.collider.gameObject);

                    } else {

                        SelectByClicking(hit.collider.gameObject);

                    }

                } else {

                    if (Input.GetKey(KeyCode.LeftShift) == false) {

                        DeselectAll();
                    
                    }
                
                }

            }

            if (Input.GetMouseButtonDown(1) && unitsSelected.Count > 0) {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, _ground)) {

                    groundMarker.transform.position = hit.point;

                    groundMarker.SetActive(false);
                    groundMarker.SetActive(true);

                }
            }

        }

        private void MultiSelect(GameObject unit) {

            if (unitsSelected.Contains(unit) == false) {

                unitsSelected.Add(unit);
                SelectUnit(unit, true);

            } else {

                SelectUnit(unit, false);
                unitsSelected.Remove(unit);
            
            }

        }

        private void SelectByClicking(GameObject unit) {

            DeselectAll();
            unitsSelected.Add(unit);
            SelectUnit(unit, true);

        }

        private void EnableUnitMovement(GameObject unit, bool shouldMove) {

            unit.GetComponent<UnitMovement>().enabled = shouldMove;

        }

        public void DeselectAll() {
            foreach (var unit in unitsSelected) {

                SelectUnit(unit, false);

            }

            unitsSelected.Clear();

        }

        private void TriggerSelectionIndicator(GameObject unit, bool isVisible) {
        
            unit.transform.GetChild(1).gameObject.SetActive(isVisible);
        
        }

        private void SelectUnit(GameObject unit, bool isSelected) {

            TriggerSelectionIndicator(unit, isSelected);
            EnableUnitMovement(unit, isSelected);

        }

        internal void DragSelect(GameObject unit) {

            if (unitsSelected.Contains(unit) == false) {

                unitsSelected.Add(unit);
                SelectUnit(unit, true);


            }

        }
    }

}
