using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class Router : IRouter
    {
        private List<Transform> _points;
        private int _pointIndex;

        public Router(ITransformPointList pointList)
        {
            _points = pointList.points;
            _pointIndex = -1;
        }

        public Transform GetNextPoint()
        {
            _pointIndex++;
            if (_pointIndex > _points.Count - 1) _pointIndex = _points.Count - 1;
            return _points[_pointIndex];
        }
    }
}
