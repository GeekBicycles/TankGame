using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tank_Game
{
    public class PlayerUIText : MonoBehaviour, IPlayerUIText
    {
        [SerializeField] private Text _PlayerTransform;
        public Text _PlayerUIText { get { return _PlayerTransform; } }
    }
}
