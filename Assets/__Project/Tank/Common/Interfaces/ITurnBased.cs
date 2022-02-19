using System;

namespace Tank_Game
{
    public interface ITurnBased
    {
        public event Action endTurn;
        public void StartTurn();
    }
}