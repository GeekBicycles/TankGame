using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class StartHelicopterPosition : IStartHelicopterPosition
    {
        private GameObject _prefab;
        private IStartupPosition _startupPosition;

        public StartHelicopterPosition()
        {
            _prefab = Resources.Load<GameObject>(ResourcesPathes.TANKS_STARTUP_POSITION);
            _startupPosition = _prefab.GetComponent<IStartupPosition>();
        }
        
        public void SetStartupPosition(IHelicopterList helicopterList)
        {
            if (helicopterList.helicopters.Count == 1)
            {
                helicopterList.helicopters[0].view.transform = _startupPosition.enemyHelicopter1;
            }
        }
    }
}
