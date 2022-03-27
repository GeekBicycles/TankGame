using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class Router : IRouter, IMemento
    {
        private List<Transform> _points;
        private int _pointIndex;
        private List<int> _indexMemento;

        public Router(ITransformPointList pointList)
        {
            _points = pointList.points;
            _pointIndex = -1;
            _indexMemento = new List<int>();
        }

        public Transform GetNextPoint()
        {
            _pointIndex++;
            if (_pointIndex > _points.Count - 1) _pointIndex = _points.Count - 1;
            return _points[_pointIndex];
        }

        public Transform GetPoint()
        {
            return _points[_pointIndex];
        }

        public void LoadMemento(int index)
        {
            if ((index > _indexMemento.Count - 1) || (index < 0))
            {
                return;
            }

            _pointIndex = _indexMemento[index];

            while (index < _indexMemento.Count - 1)
            {
                _indexMemento.RemoveAt(_indexMemento.Count - 1);
            }
        }

        public void LoadPrev()
        {
            int last = _indexMemento.Count - 1;
            LoadMemento(last - 1);
        }

        public void SaveMemento()
        {
            _indexMemento.Add(_pointIndex);
        }
    }
}
