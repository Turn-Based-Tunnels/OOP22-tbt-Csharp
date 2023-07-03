namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// The <c>GameState</c> enumeration represents the different states of the game.
    /// Each state corresponds to a specific gameplay scenario or interface.
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// Explore state, where the player moves around the environment.
        /// </summary>
        EXPLORE,

        /// <summary>
        /// Fight state, where the player engages in combat.
        /// </summary>
        FIGHT,

        /// <summary>
        /// Main menu state, where the player can choose from different options.
        /// </summary>
        MENU,

        /// <summary>
        /// Pause state, where the game is paused and the player can choose from different options.
        /// </summary>
        PAUSE,

        /// <summary>
        /// Shop state, where the player can access a shop interface.
        /// </summary>
        SHOP,

        /// <summary>
        /// Inventory state, where the player can manage their inventory.
        /// </summary>
        INVENTORY,

        /// <summary>
        /// Ending state, representing the end of the game.
        /// </summary>
        ENDING
    }
}