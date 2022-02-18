using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class ResourcesPathes : MonoBehaviour
    {
        public const string playerTankPrefab = "Prefabs/CompleteTank";
        public const string enemyTankPrefab = "Prefabs/CompleteEnemyTank";
        public const string bulletPrefab = "Prefabs/Bullet";

        public const string playerTankModel = "ScriptableObjects/Models/PlayerTankModel";
        public const string enemyTankModel = "ScriptableObjects/Models/EnemyTankModel";
        public const string bulletModel = "ScriptableObjects/Models/BulletModel";

        public const string keySetControl = "ScriptableObjects/KeySetControl/KeySetControl";
        public const string mouseSetControl = "ScriptableObjects/KeySetControl/MouseSetControl";
    }
}
