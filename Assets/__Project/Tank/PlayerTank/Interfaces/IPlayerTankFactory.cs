using UnityEngine;

namespace Tank_Game
{
    internal interface IPlayerTankFactory
    {
        public IPlayerTank GetPlayerTank(Vector3 position, Quaternion rotation);
    }
}