using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface ITransformPointList
    {
        List<Transform> points { get; }
    }
}