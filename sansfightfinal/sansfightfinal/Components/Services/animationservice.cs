using Microsoft.AspNetCore.Razor.TagHelpers;
using sansfightfinal.Components.Models;
using System.Timers;

namespace sansfightfinal.Components.Services
{
    /// <summary>
    /// handles the animation refreshing and frame updates for
    /// blasters, bones etc.
    /// also uses a timer loop to update positions and trigger visual cues
    /// </summary>
    public class animationservice
    {
        private readonly System.Timers.Timer _updateTimer;
        private readonly List<Bone> _bones = new();
        private readonly List<Blaster> _blasters = new();
        private Player? _player;

        /// <summary>
        /// used when entities are updated so UI can refresh
        /// </summary>
        public event Action? OnFrameUpdated;

        public animationservice(int intervalMs = 50)
        {
            _updateTimer = new System.Timers.Timer(intervalMs); // 20ish FPS
            _updateTimer.Elapsed += UpdateFrame;
        }

        /// <summary>
        /// starts the animation loop
        /// </summary>
        public void Start() => _updateTimer.Start();

        /// <summary>
        /// stops the animation loop
        /// </summary>
        public void Stop() => _updateTimer.Stop();

        /// <summary>
        /// registers the player for animation updates
        /// </summary>
        public void RegisterPlayer(Player player)
        {
            _player = player;
        }

        /// <summary>
        /// registers a bone for animation updates
        /// </summary>
        public void RegisterBone(Bone bone)
        {
            _bones.Clear();
            _bones.Add(bone);
        }


        public void RegisterBlaster(Blaster blasters)
        {
            _blasters.Clear();
            _blasters.Add(blasters);
        }


        private void UpdateFrame(object? sender, ElapsedEventArgs e)
        {
            // moves bones
            foreach (var bone in _bones)
            {
                bone.Move();
            }

            // moves blasters
            foreach (var blaster in _blasters)
            {
                if (_player != null && !blaster.IsPlayerSafe(_player))
                {
                    _player.ApplyKarmaDamage(blaster.KarmaRate);
                }
            }
            OnFrameUpdated?.Invoke(); //notifies UI that frame updated
        }

        /// <summary>
        /// disposes the animation timer after cycle is complete
        /// </summary>
        public void Dispose()
        {
            _updateTimer.Stop();
            _updateTimer.Dispose();
        }
    }
}
