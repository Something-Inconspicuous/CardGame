
namespace GameMechanics.Cards {
    public class BuffCard : Card {
        public readonly float damageMultiplier;
        public readonly float defenseMultiplier;

        public BuffCard(string name, string description) : base(name, description) { }

        public BuffCard(string name, string description, float damageMultiplier, float defenseMultiplier)
        : base(name, description) {
           this.damageMultiplier = damageMultiplier;
           this.defenseMultiplier = defenseMultiplier;
        }


        private static readonly CardType[] DEFAULT_BUFF = {CardType.BUFF};
        public override CardType Type(int index) => DEFAULT_BUFF[index];
        
    }    
}