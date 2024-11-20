namespace T02 {

    public class PercentageDamageModifier : IModifierDamage {

        private readonly float _percent;


        public PercentageDamageModifier(float percent) {

            _percent = percent;

        }

        public float Apply(float currentDamage) {

            return currentDamage * (1 + _percent);

        }

    }
}