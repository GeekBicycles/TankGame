using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    [CreateAssetMenu(fileName = "MouseSetControl", menuName = "KeySet/MouseSetControl", order = 2)]
    public class MouseSetControl : ScriptableObject, IMouseSetControl
    {
        [SerializeField] private KeyCode _mouse0;
        [SerializeField] private KeyCode _mouse1;
        
        public KeyCode mouse0 { get => _mouse0; set => _mouse0 = value; }
        public KeyCode mouse1 { get => _mouse1; set => _mouse1 = value; }
    }
}
