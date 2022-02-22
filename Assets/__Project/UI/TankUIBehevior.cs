using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tank_Game
{
    public class TankUIBehevior : MonoBehaviour, ITankUIBehevior
    {
        [SerializeField] private Text _PlayerCount;
        [SerializeField] private Text _EnemyCaount;
        public Text PlayerCount { get { return _PlayerCount;  } }
        public Text EnemyCaount { get{return _EnemyCaount; } }
    }
}
