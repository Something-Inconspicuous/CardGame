using UnityEngine;
using GameMechanics.Cards;

public class Tester : MonoBehaviour {
    void Start()
    {
        Card tcard = new BuffCard("Testing card", "This is the card being used for testing.");
        Debug.Log(tcard.ToString());
    }
    // TODO: test stuff
}