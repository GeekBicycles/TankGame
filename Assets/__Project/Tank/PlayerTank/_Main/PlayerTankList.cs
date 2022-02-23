using System.Collections.Generic;

namespace Tank_Game
{
    public sealed class PlayerTankList : IPlayerTankList
    {
        public List<IPlayerTank> playerTanks { get; }
        public IPlayerTank current { get; set; }

        public PlayerTankList()
        {
            playerTanks = new List<IPlayerTank>();
            current = null;
        }
        public void Remove(IPlayerTank playerTank)
        {
            playerTanks.Remove(playerTank);
            if (current == playerTank) current = null;
        }
    }
}