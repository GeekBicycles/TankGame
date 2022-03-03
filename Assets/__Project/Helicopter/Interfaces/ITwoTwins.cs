using UnityEngine;

namespace Tank_Game
{
    public interface ITwoTwins
    {
        Transform twin1 { get; }
        Transform twin2 { get; }
    }
}