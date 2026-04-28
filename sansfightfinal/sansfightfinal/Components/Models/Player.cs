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
        /// default karma level
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
        public void Move(string direction)
        {
            direction = direction.ToLower();

            int newX = Position.X;
            int newY = Position.Y;

            switch (direction)
            {
                case "up":
                case "w":
                    newY -= 10;
                    break;
                case "down":
                case "s":
                    newY += 10;
                    break;
                case "left":
                case "a":
                    newX -= 10;
                    break;
                case "right":
                case "d":
                    newX += 10;
                    break;
                default:
                    Console.WriteLine("Invalid direction. Use up/w, down/s, left/a, or right/d.");
                    break;
            }
            ClampToBox(ref newX, ref newY);
            Position = new PlayerPosition(newX, newY);
        }

        /// <summary>
        /// method for attacking Sans, which reduces his HP by the specified damage amount
        /// </summary>
        /// <param name="target">The Sans instance to attack</param>
        /// <param name="damage">The amount of damage to deal</param>
        public void Attack(Sans target, int damage)
        {
            if (target == null) return;

            target.TakeDamage(damage);
        }

        public void Act()
        {
            Console.WriteLine("You tell Sans a joke. He doesn't laugh.");
        }

        /// <summary>
        /// method for using items during the fight, which heal the player and reduce karma
        /// </summary>
        /// <param name="item">The name of the item to use</param>
        /// <returns>The amount of karma reduced</returns>
        public int UseItem(string item)
        {
            switch (item.ToLower())
            {
                case "b. pie":
                    HP += 90;
                    if (HP > 92) HP = 92; //max HP is 92
                    return 10;
                case "mysterious quiche":
                    HP += 90;
                    if (HP > 92) HP = 92;
                    return 20;
                case "legendary hero":
                    HP += 45;
                    if (HP > 92) HP = 92;
                    return 30;
                default:
                    Console.WriteLine("Invalid item. Use 'B. Pie', 'Mysterious Quiche', or 'Legendary Hero'.");
                    return 0;
            }
        }

        /// <summary>
        /// simple method for telling player that mercy is not an option in this fight,
        /// </summary>
        public void Mercy()
        {
            Console.WriteLine("Mercy is pointless at the point Partner =) ");
        }

        /// <summary>
        /// defines the dimensions of the box the player can move in,
        /// and ensures the player cannot "escape"
        /// </summary>
        private void ClampToBox(ref int x, ref int y)
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
