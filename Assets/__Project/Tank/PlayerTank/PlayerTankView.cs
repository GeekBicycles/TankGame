using UnityEngine;

namespace Tank_Game
{
    internal class PlayerTankView: IPlayerTankView
    {

        public Transform transform { get; set; }
        public Transform bulletSpawnTransform { get; set; }

        public PlayerTankBehavior playerTankBehavior { get; set; }

        public PlayerTankView(Transform transform)
        {
            this.transform = transform;
            bulletSpawnTransform = transform.GetComponentInChildren<IBulletSpawnTransform>().bulletSpawnTransform;
            playerTankBehavior = transform.gameObject.AddComponent<PlayerTankBehavior>();
        }
    }
}