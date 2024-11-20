using UnityEngine;
using UnityEngine.UI;

namespace T02 {
    public class UIToggles : MonoBehaviour {

        [SerializeField] private Toggle _addFixedDamage1;
        [SerializeField] private Toggle _addFixedDamage2;
        [SerializeField] private Toggle _addFixedDamage3;
        [SerializeField] private Toggle _addPercentDamage1;
        [SerializeField] private Toggle _addPercentDamage2;
        [SerializeField] private Toggle _addPercentDamage3;

        [SerializeField] private PlayerBonuses _playerBonuses;

        private FixedDamageModifier _fixedDamageModifier1;
        private FixedDamageModifier _fixedDamageModifier2;
        private FixedDamageModifier _fixedDamageModifier3;
        private PercentageDamageModifier _percentDamageModifier1;
        private PercentageDamageModifier _percentDamageModifier2;
        private PercentageDamageModifier _percentDamageModifier3;


        private void Start() {

            _fixedDamageModifier1 = new FixedDamageModifier(10f);
            _fixedDamageModifier2 = new FixedDamageModifier(10f);
            _fixedDamageModifier3 = new FixedDamageModifier(10f);
            _percentDamageModifier1 = new PercentageDamageModifier(0.1f);
            _percentDamageModifier2 = new PercentageDamageModifier(0.1f);
            _percentDamageModifier3 = new PercentageDamageModifier(0.1f);

            _addFixedDamage1.onValueChanged.AddListener(isOn => {


                if (isOn) {

                    _playerBonuses.AddModifier(_fixedDamageModifier1);

                } else {

                    _playerBonuses.RemoveModifier(_fixedDamageModifier1);

                }
                    
            });

            _addFixedDamage2.onValueChanged.AddListener(isOn => {



                if (isOn) {

                    _playerBonuses.AddModifier(_fixedDamageModifier2);

                } else {

                    _playerBonuses.RemoveModifier(_fixedDamageModifier2);

                }

            });

            _addFixedDamage3.onValueChanged.AddListener(isOn => {



                if (isOn) {

                    _playerBonuses.AddModifier(_fixedDamageModifier3);

                } else {

                    _playerBonuses.RemoveModifier(_fixedDamageModifier3);

                }

            });

            _addPercentDamage1.onValueChanged.AddListener(isOn => {



                if (isOn) {

                    _playerBonuses.AddModifier(_percentDamageModifier1);

                } else {

                    _playerBonuses.RemoveModifier(_percentDamageModifier1);

                }

            });

            _addPercentDamage2.onValueChanged.AddListener(isOn => {



                if (isOn) {

                    _playerBonuses.AddModifier(_percentDamageModifier2);

                } else {

                    _playerBonuses.RemoveModifier(_percentDamageModifier2);

                }

            });

            _addPercentDamage3.onValueChanged.AddListener(isOn => {


                if (isOn) {

                    _playerBonuses.AddModifier(_percentDamageModifier3);

                } else {

                    _playerBonuses.RemoveModifier(_percentDamageModifier3);

                }

            });
        }
    }
}
