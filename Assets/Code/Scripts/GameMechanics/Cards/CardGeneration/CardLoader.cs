
using System.IO;
using System.Text;
using UnityEngine;

namespace GameMechanics.Cards.CardGeneration
{

    public static class CardLoader {

        public const string JsonPath = "Assets\\Code\\Json\\Cards.json";

        public static Card[] LoadCards() {
            string json = File.ReadAllText(JsonPath);
            //Debug.Log(json);
            return JsonArrayUtility.FromJson<Card>(json);
        }

        public static void PrimeCards(params Card[] cards){
            string contents = JsonArrayUtility.ToJson(cards, prettyPrint: true);
            //Debug.Log(contents);
            File.WriteAllText(JsonPath, contents);
        } 
    }
}