using sansfightfinal.Components.Models;

namespace sansfightfinal.Components.Services
{
    public class InputHandler : IInput
    {
        private readonly Player _player;

        public InputHandler(Player player)
        {
            _player = player;
        }

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

        public async Task DodgeAsync()
        { 
            await _player.DodgeAsync();
        }

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

        public void Reset()
        {
            _player.Reset();
        }
    }
}
