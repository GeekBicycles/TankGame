using UnityEngine;

namespace Tank_Game
{
    [CreateAssetMenu(fileName = "KeySetControl", menuName = "KeySet/KeySetControl", order = 1)]
    public sealed class KeySetControl : ScriptableObject, IKeySetControl
    {
        [SerializeField] private KeyCode _up;
        [SerializeField] private KeyCode _down;
        [SerializeField] private KeyCode _left;
        [SerializeField] private KeyCode _right;
        [SerializeField] private KeyCode _fire;
        [SerializeField] private KeyCode _fireUp;

        public KeyCode up { get => _up; }
        public KeyCode down { get => _down; }
        public KeyCode left { get => _left; }
        public KeyCode right { get => _right; }
        public KeyCode fire { get => _fire; }
        public KeyCode fireUp { get => _fireUp; }
    }
}
