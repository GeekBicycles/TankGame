using UnityEngine;

namespace Tank_Game
{
    public class RunRay : IRunRay
    {
        private Camera _camera;
        private IInputMouseData _mouseData;
        
        public RunRay(Camera mainCamera, IInputMouseData mouseData)
        {
            _camera = mainCamera;
            _mouseData = mouseData;
        }

        public Transform StartRay()
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(_mouseData.mousePosition);
            if (Physics.Raycast(ray, out hit, InputSettings.MAX_RAY_LENGTH))
            {
                return hit.collider.transform;
            }
            else
            {
                return new GameObject().transform;
            }
        }
    }
}
