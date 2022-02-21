using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankFactory : IPlayerTankFactory
    {
        private IPoolGameObject _poolGameObject;
        public PlayerTankFactory()
        {
            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.PLAYER_TANK_PREFAB);
            _poolGameObject = new PoolGameObject(prefab, PrefabsNames.PLAYER_TANK, PrefabsNames.PLAYER_TANK_POOL);
        }
        public IPlayerTank GetPlayerTank(Vector3 position, Quaternion rotation)
        {
            PlayerTankModel playerTankModel = Resources.Load<PlayerTankModel>(ResourcesPathes.PLAYER_TANK_MODEL);

            GameObject gameObject = _poolGameObject.Pop();
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;

            PlayerTankView playerTankView = new PlayerTankView(gameObject.transform);

            PlayerTank playerTank = new PlayerTank(playerTankModel, playerTankView);

            playerTankView.playerTankBehavior.playerTank = playerTank;

            return playerTank;
        }

        public void Destroy(IPlayerTank playerTank)
        {
            _poolGameObject.Push(playerTank.view.transform.gameObject);
            playerTank = null;
        }
    }
}