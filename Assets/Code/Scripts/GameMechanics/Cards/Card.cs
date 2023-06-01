
using System;
using System.Text;

namespace GameMechanics.Cards {
    public class Card {
        public readonly string name;
        public readonly string description;
        public CardEffects effects;

        /// <summary>
        /// Creates a new <c>Card</c> with a given name and description
        /// </summary>
        /// <param name="name">The name of the card</param>
        /// <param name="description">The description of the card</param>
        /// <param name="damage">The damage the card deals (may be zero)</param>
        public Card(string name, string description, CardEffects effects, params CardType[] types){
            this.name = name;
            this.description = description;
            this.effects = effects;
            CardTypes = new CardTypesContainer(types);
        }

        /// <summary>
        /// Checks if a card is of a given type
        /// </summary>
        /// <remarks>
        /// Searches with O(n_1*n_2) time complexity where n_1 is the number of the Card's types
        /// and n_2 is the number of given types. When they are equal, simply O(n<sup>2</sup>)
        /// </remarks>
        /// <param name="types">The type(s) to check</param>
        /// <returns><c>True</c> if the card has the given type, <c>false</c> otherwise.</returns>
        public bool HasType(params CardType[] types){
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            for (int i = 0; i < CardTypes.Length; i++)
                for(int j = 0; j < types.Length; j++)
                    if(CardTypes[i] == types[j])
                        return true;
            return false;
        }

        public CardTypesContainer CardTypes { get; }
        /// <summary>
        /// Returns the n<sup>th</sup> type of the card
        /// </summary>
        /// <param name="index">n; the index of the type to get</param>
        /// <returns>One of the types of the card</returns>
        //public virtual CardType Type(int index) => DEFUALT_NONE[index];
        /// <summary>
        /// The number of types the card has
        /// </summary>
        /// <value>Type Count</value>
        //protected virtual int TypeCount { get => DEFUALT_NONE.Length; }

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
            for(int i = 0; i < CardTypes.Length; i++){
                CardType currType = CardTypes[i];
                str.Append($"{Enum.GetName(typeof(CardType), currType)} ");
            }
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

        /// <summary>
        /// Readonly container helper struct for card types. DO NOT USE outside of <see href="Card.cs">Card.cs</see>
        /// </summary>
        public struct CardTypesContainer {
            private CardType[] _types;
            public CardTypesContainer(params CardType[] types) => _types = types;

            public CardType this[int index] { get => _types[index]; }

            public int Count { get => _types.Length; }
            public int Length { get => _types.Length; }
        }
    }
}


