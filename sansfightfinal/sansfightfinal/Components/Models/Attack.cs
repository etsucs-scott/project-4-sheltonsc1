using sansfightfinal.Components.Services;

namespace sansfightfinal.Components.Models
{
    public class Attack : IAttack
    {
        public string Pattern { get; private set; }
        public int Duration { get; private set; }
        public int KarmaRate { get; private set; }
        public bool RequiresDodge { get; private set; }

        public Attack(string pattern, int duration, int karmaRate, bool requiresDodge)
        {
            Pattern = pattern;
            Duration = duration;
            KarmaRate = karmaRate;
            RequiresDodge = requiresDodge;
        }

        public async Task ExecuteAsync(Player player)
        {
            // Simulates attack execution
            await Task.Delay(Duration);
            if (!IsPlayerSafe(player))
            {
                player.ApplyKarmaDamage(KarmaRate);
            }
        }

        public bool IsPlayerSafe(Player player)
        {
            // determines if the player is safe
            if (RequiresDodge && player.IsDodging)
            {
                return true;
            }
            return false;
        }
    }
}
