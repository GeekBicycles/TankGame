using UnityEngine;

namespace Tank_Game
{
    [CreateAssetMenu(fileName = "BulletModel", menuName = "Models/Bullet", order = 1)]
    internal class BulletModel : ScriptableObject, IBulletModel
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;

        public float Speed { get { return _speed; } set { _speed = value; } }
        public int Damage { get { return _damage; } set { _damage = value; } }


    }
}