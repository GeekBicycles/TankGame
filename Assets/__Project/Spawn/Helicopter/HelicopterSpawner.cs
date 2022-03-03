using UnityEngine;

namespace Tank_Game
{
    public class HelicopterSpawner : IHelicopterSpawner
    {
        private IHelicopterList _helicopterList;

        public HelicopterSpawner(IHelicopterList helicopterList)
        {
            _helicopterList = helicopterList;
        }

        public void SpawnHelicopter()
        {
            IHelicopterFactory helicopterFactory = new HelicopterFactory();

            while (_helicopterList.helicopters.Count < GameSettings.ENEMY_HELICOPTER_COUNT)
            {
                IHelicopter helicopter = helicopterFactory.GetHelicopter(Vector3.zero, Quaternion.identity);
                if (helicopter != null)
                {
                    _helicopterList.helicopters.Add(helicopter);
                    _helicopterList.current = helicopter;
                }
            }
        }
    }
}
