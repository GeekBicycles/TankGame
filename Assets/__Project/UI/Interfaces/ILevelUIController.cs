using UnityEngine;

namespace Tank_Game
{
    public interface ILevelUIController
    {
       public ILevelUIBehavior levelUIBehavior { get; set; }
       public Transform canvasTransform { get; set; }
    }
}
