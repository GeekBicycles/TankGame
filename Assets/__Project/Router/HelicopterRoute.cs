using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class HelicopterRoute : MonoBehaviour, ITransformPointList
    {
        [SerializeField] private List<Transform> _points;

        public List<Transform> points { get { return _points; } }
    }
}
