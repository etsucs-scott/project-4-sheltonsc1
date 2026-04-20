namespace sansfightfinal.Components.Models
{
    public class Blaster
    {
        public int X { get; private set; } 
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Duration { get; private set; } = 5000;
        public int KarmaRate { get; private set; } = 5;
        public bool RequiresDodge { get; private set; } = true;
        public string Pattern { get; private set; } = "Gaster Blaster";
        public string Direction { get; private set; }
        public int Speed { get; private set; }

        public Blaster(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Width = 50;
            Height = 20;
            Direction = direction;
        }

        /// <summary>
        /// asynchronus task that applies karma damage is player is not in a safe zone
        /// </summary>
        public async Task ExecuteAsync(Player player)
        {
            // charges up (visual cue can be seen)
            await Task.Delay(1000);
            //firing phase
            if (!IsPlayerSafe(player))
            {
                player.ApplyKarmaDamage(KarmaRate);
            }
            //cooldown phase
            await Task.Delay(Duration - 1000);
        }

        /// <summary>
        /// checks for safety from blaster
        /// </summary>
        public bool IsPlayerSafe(Player player)
        {
            switch (Direction)
            {
                case "Left":
                    return player.Position.X > X; //safe to the left
                case "Right":
                    return player.Position.X < X; //safe to the right
                case "Up":
                    return player.Position.Y > Y; //safe above
                case "Down":
                    return player.Position.Y < Y; //safe below
                default:
                    return true;
            }
        }
    }
}
