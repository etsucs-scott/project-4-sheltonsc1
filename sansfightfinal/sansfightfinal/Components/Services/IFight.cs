using sansfightfinal.Components.Models;

namespace sansfightfinal.Components.Services
{
    /// <summary>
    /// interface defining the fight mechanics between the Player and Sans
    /// handles player actions, attacks, and fight state
    /// </summary>
    public interface IFight
    {
        /// <summary>
        /// current player
        /// </summary>
        Player Player { get; }

        /// <summary>
        /// current sans
        /// </summary>
        Sans Sans { get; }

        /// <summary>
        /// current attack being executed
        /// </summary>
        Attack CurrentAttack { get; }

        /// <summary>
        /// overall fight state
        /// </summary>
        GameState GameState { get; }

        /// <summary>
        /// list of bones currently on screen
        /// </summary>
        List<Bone> CurrentBones { get; }

        /// <summary>
        /// list of blasters currently on screen
        /// </summary>
        List<Blaster> CurrentBlasters { get; }

        /// <summary>
        /// starts the fight
        /// </summary>
        void StartFight();

        /// <summary>
        /// pauses the fight 
        ///</summary>
        void PauseFight();

        /// <summary>
        /// resumes the fight
        /// </summary>
        void ResumeFight();

        /// <summary>
        /// restarts the fight
        /// </summary>
        void RestartFight();

        /// <summary>
        /// ends the fight with victory or defeat
        /// </summary>
        /// <param name="isVictory">variable for determining win or loss</param>
        void EndFight(bool isVictory);

        /// <summary>
        /// moves the player in the specified direction
        /// </summary>
        /// <param name="direction">variable for the player's input</param>
        void MovePlayer(string direction);

        /// <summary>
        /// executes sans's next attack
        /// </summary>
        Task ExecuteNextAttackAsync();

        /// <summary>
        /// handles dodge input and attack outcome
        /// </summary>
        /// <param name="success">true is dodged, false as default</param>
        void HandleDodge(bool success);

        /// <summary>
        /// handles the spawning of bones and blasters on the board
        /// </summary>
        /// <param name="bone">bone being spawned</param>
        void SpawnBone(Bone bone);
    }
}
