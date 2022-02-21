using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tank_Game
{
    public class EnemyUIText : MonoBehaviour, IEnemyUIText
    {
        [SerializeField] private Text _EnemyTransform;
        public Text _EnemyUIText { get { return _EnemyTransform; } }
    }
}
