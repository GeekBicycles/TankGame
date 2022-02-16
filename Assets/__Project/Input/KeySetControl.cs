using System.Collections;
using System.Collections.Generic;
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

        public KeyCode up { get => _up; set => _up = value; }
        public KeyCode down { get => _down; set => _down = value; }
        public KeyCode left { get => _left; set => _left = value; }
        public KeyCode right { get => _right; set => _right = value; }
        public KeyCode fire { get => _fire; set => _fire = value; }
    }
}
