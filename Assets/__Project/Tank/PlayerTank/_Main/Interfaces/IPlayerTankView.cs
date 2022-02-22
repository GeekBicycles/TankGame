using UnityEngine;

namespace Tank_Game
{
    public interface IPlayerTankView
    {
        public Transform transform { get; }
        public Transform bulletSpawnTransform { get; }
        public PlayerTankBehavior playerTankBehavior { get; }
        public HealthSlider healthSlider { get; set; }
        public FireSlider fireSlider { get; set; }
    }
}