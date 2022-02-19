using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankFactory : IPlayerTankFactory
    {
        public IPlayerTank GetPlayerTank(Vector3 position, Quaternion rotation)
        {
            PlayerTankModel playerTankModel = Resources.Load<PlayerTankModel>(ResourcesPathes.PLAYER_TANK_MODEL);

            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.PLAYER_TANK_PREFAB);
            GameObject gameObject = GameObject.Instantiate(prefab, position, rotation);
            gameObject.name = PrefabsNames.PLAYER_TANK;
            PlayerTankView playerTankView = new PlayerTankView(gameObject.transform);

            PlayerTank playerTank = new PlayerTank(playerTankModel, playerTankView);

            return playerTank;
        }
    }
}