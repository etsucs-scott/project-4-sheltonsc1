namespace sansfightfinal.Components.Models
{
    public class Bone
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } = 20;
        public int Height { get; set; } = 80;
        public string Direction { get; set; } = "right";
        public int Speed { get; set; } = 5;

        public Bone(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
        /// <summary>
        /// moves the bone in its set direction
        /// </summary>
        public void Move()
        {
            switch (Direction)
            {
                case "up":
                    Y -= Speed; break;
                case "down":
                    Y += Speed; break;
                case "left":
                    X -= Speed; break;
                case "right":
                    X += Speed; break;
            }
        }

        /// <summary>
        /// checks for collision with the player
        /// </summary>
        public bool CollidesWith(Player player)
        {
            return player.Position.X < X + Width &&
                   player.Position.X + 15 > X &&
                   player.Position.Y < Y + Height &&
                   player.Position.Y + 15 > Y;
        }
    }
}
