using System.Collections.Generic;
using UnityEngine;

namespace JsonTwoFactories
{
    public sealed class Starter : MonoBehaviour
    {
        public List<Unit> units;
        void Start()
        {
            Game game = new Game();
            game.Start(this);
        }
    }
}
