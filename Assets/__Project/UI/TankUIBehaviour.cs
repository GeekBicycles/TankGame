using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tank_Game
{
    public class TankUIBehaviour : MonoBehaviour, ITankUIBehaviour
    {
        [SerializeField] private Text _playerCount;
        [SerializeField] private Text _enemyCount;
        public Text playerCount { get { return _playerCount;  } }
        public Text enemyCount { get{return _enemyCount; } }
    }
}
