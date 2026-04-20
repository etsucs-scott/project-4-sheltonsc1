using sansfightfinal.Components.Models;

namespace sansfightfinal.Components.Services
{
    /// <summary>
    /// interface defining an attack pattern by Sans
    /// handles execution and properties of the attack
    /// </summary>
    public interface IAttack
    {
        /// <summary>
        /// name of attack
        /// </summary>
        string Pattern { get; }

        /// <summary>
        /// duration of the attack in milliseconds
        /// </summary>
        int Duration { get; }

        /// <summary>
        /// rate of "karma" applied when player's dodging is failed
        /// </summary>
        int KarmaRate { get; }

        /// <summary>
        /// requires the player to dodge the attack
        /// </summary>
        bool RequiresDodge { get; }

        /// <summary>
        /// executes the attack on the player
        /// </summary>
        /// <param name="player">player = target</param>
        Task ExecuteAsync(Player player);

        /// <summary>
        /// checks if player is in a safe zone
        /// </summary>
        /// <param name="player">the player to check</param>
        /// <returns>true if safe, false is default</returns>
        bool IsPlayerSafe(Player player);
    }
}
