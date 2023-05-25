
using System.Collections.Generic;

namespace GameMechanics.Cards {
    public class Hand {
        //probably will not be a constant if we have variable hand size as a power eg. drawing more cards per turn
        public const int MAX_CARDS = 7;

        private List<Card> cards;

        public Hand(){
            
        }

        public Hand(params Card[] cards){
            this.cards = new List<Card>(cards);
        }

        public Card this[int index] {
            get => cards[index];
        }
        
    }    
}
