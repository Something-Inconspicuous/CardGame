using UnityEngine;
using GameMechanics.Cards;
using GameMechanics.Enemy;

public class Tester : MonoBehaviour {
    void Start()
    {
        Card tcard = new Card(name: "Testing card", description: "This is the card being used for testing.", damage: 1);
        Debug.Log(tcard.ToString());

        
    }
    // TODO: test stuff
}