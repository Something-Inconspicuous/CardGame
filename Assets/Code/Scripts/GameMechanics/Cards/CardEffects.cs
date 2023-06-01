
using System;

namespace GameMechanics.Cards {
    public struct CardEffects {
        public int damage;

        public CardTarget target;

        public float multiplier;

        public CardEffects(float multiplier = 1.0f) : this() {
            this.multiplier = multiplier;
        }

        public static CardEffects operator*(CardEffects left, CardEffects right){
            left.damage = (int)((float)left.damage * right.multiplier);
            return left;
        }
    }
}