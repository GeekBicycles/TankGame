using UnityEngine;

namespace Tank_Game
{
    public sealed class ResourcesPathes : MonoBehaviour
    {
        public const string PLAYER_TANK_PREFAB = "Prefabs/CompleteTank";
        public const string ENEMY_TANK_PREFAB = "Prefabs/CompleteEnemyTank";
        public const string BULLET_PREFAB = "Prefabs/Bullet";
        public const string BULLET_PREFAB_BUILDER = "Prefabs/BulletBuilder";
        public const string PLAYER_TANK_MODEL = "ScriptableObjects/Models/PlayerTankModel";
        public const string ENEMY_TANK_MODEL = "ScriptableObjects/Models/EnemyTankModel";
        public const string BULLET_MODEL = "ScriptableObjects/Models/BulletModel";
        public const string KEY_SET_CONTROL = "ScriptableObjects/KeySetControl/KeySetControl";
        public const string MOUSE_SET_CONTROL = "ScriptableObjects/KeySetControl/MouseSetControl";
        public const string TANKS_STARTUP_POSITION = "Prefabs/TanksStartupPosition";
        public const string END_GAME_CANVAS = "UI/EndGameCanvas";
        public const string EXPLOSION_EFFECT_PREFAB = "Prefabs/TankExplosion";
    }
}
