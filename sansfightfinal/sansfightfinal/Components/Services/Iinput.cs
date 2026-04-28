using sansfightfinal.Components.Models;

namespace sansfightfinal.Components.Services
{
    /// <summary>
    /// defines input handling for player actions
    /// </summary>
    public interface IInput
    {
        /// <summary>
        /// handles directional movement
        /// </summary>
        /// <param name="direction">movement direction string</param>
        void Move(string direction);

        /// <summary>
        /// handles dodge input
        /// </summary>
        Task DodgeAsync();

        /// <summary>
        /// handles action input
        /// </summary>
        void Action(string action, Sans target, string item);

        /// <summary>
        /// resets inputs
        /// </summary>
        void Reset();
    }
}
