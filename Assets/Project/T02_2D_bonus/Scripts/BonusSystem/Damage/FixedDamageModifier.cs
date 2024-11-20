namespace T02 {

    public class FixedDamageModifier : IModifierDamage {

        private readonly float _bonus;

        public FixedDamageModifier(float bonus) {

            _bonus = bonus;

        }

        public float Apply(float currentDamage) {

            return currentDamage + _bonus;

        }
    }
}
