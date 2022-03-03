using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class HelicopterTwinTransform : MonoBehaviour, ITwoTwins
    {
        [SerializeField] private Transform _twin1;
        [SerializeField] private Transform _twin2;

        public Transform twin1 { get { return _twin1; } }
        public Transform twin2 { get { return _twin2; } }
    }
}
