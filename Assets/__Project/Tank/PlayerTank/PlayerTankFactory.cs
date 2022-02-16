using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankFactory : IPlayerTankFactory
    {
        public IPlayerTank GetPlayerTank(Vector3 position, Quaternion rotation)
        {
            PlayerTankModel playerTankModel = Resources.Load<PlayerTankModel>(ResourcesPathes.playerTankModel);
            playerTankModel.maxTimeToFire = 0.1f;
            playerTankModel.timeToFire = playerTankModel.maxTimeToFire;

            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.playerTankPrefab);
            GameObject gameObject = GameObject.Instantiate(prefab, position, rotation);
            gameObject.name = PrefabsNames.playerTankName;
            PlayerTankView playerTankView = new PlayerTankView(gameObject.transform);

            PlayerTank playerTank = new PlayerTank(playerTankModel, playerTankView);

            return playerTank;
        }
    }
}