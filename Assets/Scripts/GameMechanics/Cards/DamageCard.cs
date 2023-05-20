
namespace GameMechanics.Cards {
    public class DamageCard : Card {
        public readonly int damage;

        public DamageCard(string name, string description, int damage) : base(name, description){
            this.damage = damage;
        }


        private static readonly CardType[] DEFAULT_DAMAGE = {CardType.DAMAGE}; 
        public override CardType Type(int index) => DEFAULT_DAMAGE[index];
    }
}


