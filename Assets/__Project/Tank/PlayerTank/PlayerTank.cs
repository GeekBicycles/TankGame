using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTank : IPlayerTank
    {
        public IPlayerTankModel model { get; set; }
        public IPlayerTankView view { get; set; }

        public float timeToFire { get; set; }

        public PlayerTank(IPlayerTankModel model, IPlayerTankView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}