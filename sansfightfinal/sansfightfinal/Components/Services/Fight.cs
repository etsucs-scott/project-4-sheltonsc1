using sansfightfinal.Components.Models;

namespace sansfightfinal.Components.Services
{
    public class Fight : IFight
    {
        private readonly IInput _input;
        public Player Player { get; private set; } = new Player();
        public Sans Sans { get; private set; } = new Sans();
        public Attack CurrentAttack { get; private set; }
        public GameState GameState { get; private set; } = new GameState();
        public List<Blaster> CurrentBlasters { get; private set; } = new();
        public List<Bone> CurrentBones { get; private set; } = new();

        public Fight(IInput input, Attack currentAttack)
        {
            _input = input;
            CurrentAttack = currentAttack;
        }

        /// <summary>
        /// starts a new fight by
        /// resetting the game state, 
        /// the player, and Sans to prefight conditions
        /// </summary>
        public void StartFight()
        {
            GameState.StartFight();
            Player.Reset();
            Sans.Reset();
            CurrentAttack = (Attack)Sans.GetNextAttack();
            CurrentBones = new List<Bone>();
        }

        public void PauseFight()
        {
            GameState.PauseFight();
        }

        public void ResumeFight()
        {
            GameState.ResumeFight();
        }

        public void RestartFight()
        {
            GameState.Reset();
            Player.Reset();
            Sans.Reset();
            CurrentAttack = (Attack)Sans.GetNextAttack();
            CurrentBones = new List<Bone>();
        }

        public void EndFight(bool isVictory)
        {
            GameState.EndFight(isVictory);
        }

        public void MovePlayer(string direction)
        {
            var pos = Player.Position;
            Player.Move(direction);

            foreach (var bone in CurrentBones)
            {
                if (bone.CollidesWith(Player))
                {
                    Player.ApplyKarmaDamage(CurrentAttack.KarmaRate);
                    if (Player.HP <= 0)
                    {
                        GameState.EndFight(true);
                    }
                }
            }
        }

        public async Task ExecuteNextAttackAsync()
        {
            CurrentAttack = (Attack)Sans.GetNextAttack();
            await CurrentAttack.ExecuteAsync(Player);

            if (Player.HP <= 0)
            {
                GameState.EndFight(true);
            }
        }

        public void HandleDodge(bool success)
        {
            if (!success)
            {
                Player.ApplyKarmaDamage(CurrentAttack.KarmaRate);
                if (Player.HP <= 0)
                {
                    GameState.EndFight(true);
                }
            }
        }

        /// <summary>
        /// spawns a pattern of bones on the screen
        /// </summary>
        public void SpawnBones()
        {
            CurrentBones.Clear();

            switch (CurrentAttack.Pattern)
            {
                case "Gaster Blaster":
                    CurrentBlasters.Add(new Blaster(100, 0, "left"));
                    break;
                case "Bone Barrage":
                    CurrentBones.Add(new Bone { X = 0, Y = 0, Width = 150, Height = 20, Direction = "right", Speed = 3 });
                    break;
                case "Bone Wave":
                    for (int i = 0; i < 5; i++)
                    {
                        CurrentBones.Add(new Bone { X = 0, Y = i * 40, Width = 20, Height = 200, Direction = "up", Speed = 3 });
                    };
                    break;
                case "Bone Wall":
                    for (int i = 0; i < 4; i++)
                    {
                        CurrentBones.Add(new Bone { X = i * 60, Y = 0, Width = 50, Height = 300, Direction = "down", Speed = 2 });
                    };
                    break;
                case "Parkour":
                    for (int i = 0; i < 3; i++)
                    {
                        CurrentBones.Add(new Bone { X = i * 100, Y = 0, Width = 30, Height = 150, Direction = "right", Speed = 4 });
                    };
                    break;
            }
        }
    }
}
