using UnityEngine;

namespace Tank_Game
{
    internal class PlayerTankView: IPlayerTankView
    {
        public Transform transform { get; }
        public Transform bulletSpawnTransform { get; }
        public PlayerTankBehavior playerTankBehavior { get; }

        public PlayerTankView(Transform transform)
        {
            this.transform = transform;
            bulletSpawnTransform = transform.GetComponentInChildren<IBulletSpawnTransform>().bulletSpawnTransform;
            playerTankBehavior = transform.gameObject.AddComponent<PlayerTankBehavior>();
        }
    }
}