
namespace GameMechanics.Cards {
    /// <summary>
    /// Represents what a card effects when it's effects are resolved.
    /// </summary>
    /// <remarks>
    /// Multiple targets can be represented by a single instance by using
    /// the bitwise <see langword="or"/> (<c>|</c>) operator For example:
    /// <code>
    /// CardTarget target = CardTarget.LEFT_CARD | CardTarget.RIGHT_CARD
    /// </code>
    /// a card with the above target will apply its effects to both of
    /// the cards to its left and right
    /// </remarks>
    [System.Flags]
    public enum CardTarget : byte {
        NONE        = (byte)0,
        PLAYER      = (byte)1,
        ENEMY       = (byte)2,
        ALL_CARDS   = (byte)4,
        LEFT_CARD   = (byte)8,
        RIGHT_CARD  = (byte)16,
        LEFT_CARDS  = (byte)32,
        RIGHT_CARDS = (byte)64,
        EVERYTHING  = (byte)255
    }
}
