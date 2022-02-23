using System.Collections.Generic;

namespace Tank_Game
{
    public interface IPlayerTankList
    {
        public List<IPlayerTank> playerTanks { get; }
        public IPlayerTank current { get; set; }
        public void Remove(IPlayerTank playerTank);
    }
}