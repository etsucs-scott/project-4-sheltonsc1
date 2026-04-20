using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace sansfightfinal.Components.Models
{
    /// <summary>
    /// represents the player,
    /// tracks the player's HP and other stats
    /// </summary>
    public class Player
    {
        /// <summary>
        /// player's HP (health points)
        /// </summary>
        public int HP { get; set; } = 92;

        /// <summary>
        /// current karma level
        /// </summary>
        public int Karma { get; private set; } = 0;

        /// <summary>
        /// current position of the player in the box
        /// </summary>
        public PlayerPosition Position { get; private set; } = new PlayerPosition(140, 90); //default center

        /// <summary>
        /// true if player is dodging an attack
        /// </summary>
        public bool IsDodging { get; set; } = false;

        /// <summary>
        /// gives the player the ability to move
        /// </summary>
        public void Move(string direction, int x, int y, int step = 10)
        {
            switch (direction)
            {
                case "up":
                    y -= step; break;
                case "down":
                    y -= step; break;
                case "left":
                    x -= step; break;
                case "right":
                    x -= step; break;
            }
            ClampToBox(x,y);
        }

        /// <summary>
        /// defines the dimensions of the box the player can move in,
        /// and ensures the player cannot "escape"
        /// </summary>
        private void ClampToBox(int x, int y)
        {
            x = Math.Clamp(x, 0, 280); //box width 280
            y = Math.Clamp(y, 0, 180); //box height 180
        }

        /// <summary>
        /// applies karma damage to the player
        /// </summary>
        public void ApplyKarmaDamage(int rate)
        {
            Karma += rate;
            HP -= rate;
            if (HP < 0) HP = 0;
        }

        /// <summary>
        /// sets the player's dodging state for a small window
        /// </summary>
        public async Task DodgeAsync(int durationMs = 500)
        {
            IsDodging = true;
            await Task.Delay(durationMs);
            IsDodging = false;
        }

        /// <summary>
        /// resets the player's stats to prefight values
        /// </summary>
        public void Reset()
        {
            HP = 92;
            Karma = 0;
            Position = new PlayerPosition(140, 90);
            IsDodging = false;
        }

        /// <summary>
        /// creates the position struct for the player,
        /// which allows movement within the box
        /// </summary>
        public struct PlayerPosition
        {
            public int X { get; set; }
            public int Y { get; set; }
            public PlayerPosition(int x, int y)
            {
                X = x;
                Y = y;
            }

            public string Xpx => $"{X}px";
            public string Ypx => $"{Y}px";
        }
    }
}
