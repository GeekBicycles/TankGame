using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tank_Game
{
    public class TankUIView : ITankUIView
    {
        public float PlayerTankCount { get; set; }
        public float EnemyTankCount { get; set; }
        public Text PlayerCountText { get; set; }
        public Text EnemyCountText { get; set; }
        public Transform canvas { get; }
        public TankUIView(Transform transform)
        {
            canvas = transform;
            PlayerCountText = transform.GetComponentInChildren<IPlayerUIText>()._PlayerUIText;
            EnemyCountText = transform.GetComponentInChildren<IEnemyUIText>()._EnemyUIText;
        }
    }
}
