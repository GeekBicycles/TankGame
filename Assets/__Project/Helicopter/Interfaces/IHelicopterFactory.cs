using UnityEngine;

namespace Tank_Game
{
    public interface IHelicopterFactory
    {
        public IHelicopter GetHelicopter(Vector3 position, Quaternion rotation);

        public void Destroy(IHelicopter helicopter);
    }
}
