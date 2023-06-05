using UnityEngine;
using GameMechanics.Cards;
using GameMechanics.Cards.CardGeneration;
using GameMechanics.Enemy;

public class Tester : MonoBehaviour {
    Card[] cards;

    void Start(){
        cards = CardLoader.LoadCards();
        foreach (Card card in cards) {
            Debug.Log(card);
        }
    }
    // TODO: test stuff
}