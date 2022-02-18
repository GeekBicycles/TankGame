using System.Collections;
using System.Collections.Generic;
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

        public Collider StartRay()
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                return hit.collider;
            }
            else
            {
                return new Collider();
            }
        }
    }
}
