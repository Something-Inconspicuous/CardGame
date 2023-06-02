
using System;
using System.Text;

namespace GameMechanics.Cards {
    [System.Serializable]
    public class Card {
        public string name;
        public string description;
        public CardEffects effects;

        /// <summary>
        /// Creates a new <c>Card</c> with a given name and description
        /// </summary>
        /// <param name="name">The name of the card</param>
        /// <param name="description">The description of the card</param>
        /// <param name="damage">The damage the card deals (may be zero)</param>
        public Card(string name, string description, CardEffects effects){
            this.name = name;
            this.description = description;
            this.effects = effects;
        }

        /// <summary>
        /// Returns a string representation of the <see cref="Card"/>.
        /// </summary>
        /// <example>
        /// The string will follow the format
        /// 
        /// [name] : [types...]
        /// [description]
        /// </example>
        /// <returns>A string representation of the <see cref="Card"/></returns>
        public override string ToString() {
            StringBuilder str = new StringBuilder($"{name} : ");
            return str.Append('\n').Append(description).ToString();
        }

        //        /// <summary>
        //        /// Cards are considered the same if they have the same <see cref="name"/>
        //        /// </summary>
        //        /// <param name="card">Given card</param>
        //        /// <returns><c>True</c> if both are the same card (have the same name), <c>false</c> otherwise</returns>
        //        bool IEquatable<Card>.Equals(Card card) => this.name == card.name;
        //  
        //        public override bool Equals(object obj){
        //            if (obj == null || GetType() != obj.GetType())
        //                return false;
        //            
        //            return IEquatable<Card>.Equals((Card)obj);
        //        }
        //
        //        public override int GetHashCode() => name.GetHashCode();
    }
}


