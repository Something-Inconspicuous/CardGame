
using System.Text;

namespace GameMechanics.Cards {
    [System.Serializable]
    public struct CardEffects {
        public int damage;

        public CardTarget target;

        public float multiplier;

        public CardEffects(float multiplier = 1.0f) : this() {
            this.multiplier = multiplier;
        }

        public override string ToString() {
            StringBuilder str =  new StringBuilder($"\tDamage: {damage}\n\tMultiplier: {multiplier}\n\tTargets: ");
            for(int i = 0; i < 8; i++){
                CardTarget ct = (CardTarget)(1 << i);
                if((target & ct) == ct){
                    str.Append(ct).Append(' ');
                }
            }
            return str.ToString();
        }

        public static CardEffects operator*(CardEffects left, CardEffects right){
            return left * right.multiplier;
        }

        public static CardEffects operator*(CardEffects left, float right){
            left.multiplier *= right;
            left.damage = (int)((float)left.damage * right);
            return left;
        }
    }
}