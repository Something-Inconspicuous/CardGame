
using System.Collections;
using System.Collections.Generic;

namespace GameMechanics.Cards {
    public class Hand : List<Card> {
        public Hand(params Card[] cards) : base(cards) {}
    }    
}
