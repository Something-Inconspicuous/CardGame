using UnityEngine;
using GameMechanics.Cards;
using GameMechanics.Enemy;

public class Tester : MonoBehaviour {
    void Start()
    {
        CardEffects efMult = new CardEffects();
        efMult.multiplier = 2.0f;
        efMult.target = CardTarget.LEFT_CARD;

        CardEffects ef2 = new CardEffects(1.0f);
        ef2.damage = 2;
        Card tcard2 = new Card(
            name: "other",
            description: "Other card for testing",
            effects: ef2,
            types: CardType.DAMAGE
        );

        CardEffects efMult2 = new CardEffects();
        efMult2.multiplier = 2.0f;
        efMult2.target = CardTarget.LEFT_CARD;

        Card tcardMult2 = new Card(
            name: "otherother",
            description: "Otherother card",
            effects: efMult2,
            types: CardType.BUFF
        );

        CardEffects efAllMult = new CardEffects();
        efAllMult.multiplier = 2.0f;
        efAllMult.target = CardTarget.ALL_CARDS;

        Card tcardAllMult = new Card(
            name: "All",
            description: "multiply all",
            effects: efAllMult,
            types: CardType.BUFF
        );

        Card tcardMult = new Card(
            name: "Testing card",
            description: "This is the card being used for testing.",
            effects: efMult,
            types: CardType.BUFF
        );
        //tcard.effects *= ef;
        Debug.Log(tcardMult.ToString());

        //                                            2dmg,   x2<-       x2<-        x2all
        CardEffects teff = CardResolveManager.Resolve(tcard2, tcardMult, tcardMult2, tcardAllMult);

        Debug.Log($"{teff.damage} {teff.multiplier}");

        
    }
    // TODO: test stuff
}