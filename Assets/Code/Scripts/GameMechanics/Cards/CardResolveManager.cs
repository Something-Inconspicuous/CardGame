
namespace GameMechanics.Cards {
    public static class CardResolveManager {
        //List<Card> effects;
        
        
        public static CardEffects Resolve(params Card[] cards){

            // Apply original buffs to wild cards
            for (int i = 0; i < cards.Length; i++){
                if(cards[i].effects.target != CardTarget.ALL_CARDS) continue;

                ApplyFromLeft(ref cards, i, cards.Length);
                ApplyFromRight(ref cards, i, 0);
            }

            float globalMult = 1.0f;

            // Find wild card buffs total
            for (int i = 0; i < cards.Length; i++){
                if(cards[i].effects.target != CardTarget.ALL_CARDS) continue;

                globalMult *= cards[i].effects.multiplier;
            }
            
            // Apply wild card buffs total to all cards
            for (int i = 0; i < cards.Length; i++){
                cards[i].effects.multiplier *= globalMult;
                cards[i].effects.damage = (int)((float)cards[i].effects.damage * globalMult);
            }

            // Apply left to right buffs
            for (int i = 0; i < cards.Length - 1; i++){
                switch (cards[i].effects.target) {
                    case CardTarget.RIGHT_CARD:

                        cards[i + 1].effects.multiplier *= cards[i].effects.multiplier;
                        cards[i + 1].effects.damage = (int)((float)cards[i + 1].effects.damage * cards[i].effects.multiplier);

                        break;
                    case CardTarget.RIGHT_CARDS:

                        for (int j = i + 1; j < cards.Length; j++) {
                            cards[j].effects.multiplier *= cards[i].effects.multiplier;
                            cards[j].effects.damage = (int)((float)cards[j].effects.damage * cards[i].effects.multiplier);
                        }

                        break;
                }
            }

            // Apply right to left buffs
            for (int i = cards.Length - 1; i > 0 ; i--){
                switch (cards[i].effects.target) {
                    case CardTarget.LEFT_CARD:

                        cards[i - 1].effects.multiplier *= cards[i].effects.multiplier;
                        cards[i - 1].effects.damage = (int)((float)cards[i - 1].effects.damage * cards[i].effects.multiplier);
                        
                        break;
                    case CardTarget.LEFT_CARDS: 

                        for (int j = i - 1; j >= 0; j--){
                            cards[j].effects.multiplier *= cards[i].effects.multiplier;
                            cards[j].effects.damage = (int)((float)cards[j].effects.damage * cards[i].effects.multiplier);
                        }

                        break;
                        
                }
            }

            // Get final damage
            CardEffects finals = new CardEffects();
            finals.target = CardTarget.ENEMY;
            foreach(Card card in cards){
                finals.damage += card.effects.damage;
            }

            return finals;
        }

        private static void ApplyFromLeft(ref Card[] cards, int start, int end) {
            ref Card card = ref cards[start];
            bool streak = false;
            for (int i = start + 1; i < end; i++) {
                ref Card card2 = ref cards[i];

                // If a card is to the right of this card, and it targets the card to its left
                // it is targeting this card
                if (card2.effects.target == CardTarget.LEFT_CARD && (i == start + 1 || streak)) {
                    streak = true;
                    card.effects.multiplier *= card2.effects.multiplier;
                    card.effects.damage = (int)((float)card.effects.damage * card2.effects.multiplier);
                } else {
                    streak = false;
                }

                if(card2.effects.target == CardTarget.LEFT_CARDS){
                    card.effects.multiplier *= card2.effects.multiplier;
                    card.effects.damage = (int)((float)card.effects.damage * card2.effects.multiplier);
                }
            }
        }

        private static void ApplyFromRight(ref Card[] cards, int start, int end) {
            ref Card card = ref cards[start];
            bool streak = false;
            for (int i = start - 1; i >= end ; i--){
                ref Card card2 = ref cards[i];

                if(card2.effects.target == CardTarget.RIGHT_CARD && (i == start - 1 || streak)){
                    streak = true;
                    card.effects.multiplier *= card2.effects.multiplier;
                    card.effects.damage = (int)((float)card.effects.damage * card2.effects.multiplier);
                } else {
                    streak = false;
                }

                if(card2.effects.target == CardTarget.RIGHT_CARDS){
                    card.effects.multiplier *= card2.effects.multiplier;
                    card.effects.damage = (int)((float)card.effects.damage * card2.effects.multiplier);
                }
            }
        }


        //public static CardEffects CompileEffects(){
        //    return (1,"2");
        //}

        //override string ToString(){
        //    //return string of all effects applied in order
        //    return "";
        //}

    }

}