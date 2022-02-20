using UnityEngine;

namespace Tank_Game
{
    public interface IPlayerTankFactory
    {
        public IPlayerTank GetPlayerTank(Vector3 position, Quaternion rotation);
    }
}