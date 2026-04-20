namespace sansfightfinal.Components.Models
{
    /// <summary>
    /// represents the overall state of the game, 
    /// including player stats, current level, 
    /// and other relevant information.
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// determines if a fight is currently active
        /// </summary>
        public bool IsFightActive { get; private set; }

        /// <summary>
        /// determines if the player has won the fight
        /// </summary>
        public bool IsVictory { get; private set; }

        /// <summary>
        /// determines if the player lost the fight
        /// </summary>
        public bool IsGameOver { get; private set; }

        /// <summary>
        /// determines if the fight is paused
        /// </summary>
        public bool IsPaused { get; private set; }

        /// <summary>
        /// constructor with default settings
        /// </summary>
        public GameState()
        {
            IsFightActive = false;
            IsVictory = false;
            IsGameOver = false;
            IsPaused = false;
        }

        /// <summary>
        /// starts the fight
        /// </summary>
        public void StartFight()
        {
            IsFightActive = true;
        }

        /// <summary>
        /// pauses the fight
        /// </summary>
        public void PauseFight()
        {
            if (IsFightActive && !IsGameOver && !IsVictory)
            {
                IsPaused = true;
            }
        }

        /// <summary>
        /// resumes the fight
        /// </summary>
        public void ResumeFight()
        {
            if (IsPaused)
            {
                IsPaused = false;
            }
        }

        /// <summary>
        /// resets the game state to prefight conditions
        /// </summary>
        public void Reset()
        {
            IsFightActive = false;
            IsVictory = false;
            IsGameOver = false;
            IsPaused = false;
        }

        /// <summary>
        /// ends the fight with victory or defeat
        /// </summary>
        /// <param name="victory">a true/false value for if the player dies or wins</param>
        public void EndFight(bool victory)
        {
            IsFightActive = false;
            if (victory)
            {
                IsVictory = true;
            }
            else
            {
                IsGameOver = true;
            }
        }
    }
}
