using sansfightfinal.Components.Models;

namespace sansfightfinal.Components.Services
{
    public class InputHandler : IInput
    {
        /// <summary>
        /// readonly for the player instance to ensure consistent state across inputs
        /// </summary>
        private readonly Player _player;

        /// <summary>
        /// new instance of input handler, requires a player instance to manage inputs for
        /// </summary>
        /// <param name="player">The player instance to be used by the input handler</param>
        public InputHandler(Player player)
        {
            _player = player;
        }

        /// <summary>
        /// method for handling movement input, takes a direction string and moves the player accordingly
        /// </summary>
        /// <param name="direction">The direction in which the player should move.</param>
        public void Move(string direction)
        {
            direction = direction.ToLower();

            switch (direction)
            {
                case "up":
                case "w":
                    _player.Move(direction);
                    break;
                case "down":
                case "s":
                    _player.Move(direction);
                    break;
                case "left":
                case "a":
                    _player.Move(direction);
                    break;
                case "right":
                case "d":
                    _player.Move(direction);
                    break;
                default:
                    Console.WriteLine("Invalid direction. Use up/w, down/s, left/a, or right/d.");
                    break;
            }
        }

        /// <summary>
        /// Asynchronously performs a dodge action for the player.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DodgeAsync()
        { 
            await _player.DodgeAsync();
        }

        /// <summary>
        /// Performs an action for the player based on the specified action string.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        /// <param name="target">The target of the action.</param>
        /// <param name="item">The item to use, if applicable.</param>
        public void Action(string action, Sans target, string item)
        {
            action = action.ToLower();

            switch (action)
            {
                case "fight":
                case "1":
                    _player.Attack(target, 99);
                    break;
                case "act":
                case "2":
                    _player.Act();
                    break;
                case "item":
                case "3":
                    _player.UseItem(item);
                    break;
                case "mercy":
                    case "4":
                    _player.Mercy();
                    break;
                default:
                    Console.WriteLine("Invalid action. Use fight/1, act/2, item/3, or mercy/4.");
                    break;
            }
        }

        /// <summary>
        /// resets the player's state to the initial conditions, allowing for a fresh start in the fight
        /// </summary>
        public void Reset()
        {
            _player.Reset();
        }
    }
}
