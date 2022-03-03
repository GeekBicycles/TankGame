using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class HelicopterController : IUpdate, IHelicopterController
    {
        private IHelicopterList _helicopterList;
        private IHelicopterFactory _helicopterFactory;
        private ISmoothRouter _router;
        private IHelicopterMoveController _moveController;
        private ITwinController _upTwinController;
        private ITwinController _downTwinController;

        public HelicopterController(IHelicopterList helicopterList)
        {
            _helicopterList = helicopterList;
            _helicopterFactory = new HelicopterFactory();
            
            AddReactionOnBullet();

            GameObject helicopterRoute = Resources.Load<GameObject>(ResourcesPathes.HELICOPTER_ROUTE_POINTS);
            ITransformPointList transformPointList = helicopterRoute.GetComponent<ITransformPointList>();
            float moveSpeed = _helicopterList.current.model.moveSpeed;
            float rotateSpeed = _helicopterList.current.model.rotateSpeed;
            _router = new SmoothRouter(transformPointList, _helicopterList.current.view.transform, moveSpeed, rotateSpeed);
            _moveController = new HelicopterMoveController(_helicopterList.current.view.transform, moveSpeed, rotateSpeed);

            _upTwinController = new TwinController(_helicopterList.current, _helicopterList.current.view.twin1, false);
            _upTwinController.SetTwinSpeed(_helicopterList.current.model.maxTwinSpeed);
            _downTwinController = new TwinController(_helicopterList.current, _helicopterList.current.view.twin2, true);
            _downTwinController.SetTwinSpeed(_helicopterList.current.model.maxTwinSpeed);
        }

        private void AddReactionOnBullet()
        {
            foreach (IHelicopter helicopter in _helicopterList.helicopters)
            {
                helicopter.view.helicopterBehaviour.actionOnColliderEnter += OnCollisionEnter;
            }
        }
        
        public void Update(float deltaTime)
        {
            _upTwinController.Update(deltaTime);
            _downTwinController.Update(deltaTime);
            if (_upTwinController.SpeedReached() && _downTwinController.SpeedReached())
            {
                _router.Update(deltaTime);
                _moveController.SetDestination(_router.GetTarget());
                _moveController.Update(deltaTime);
            }
        }

        public IHelicopterList GetHelicopterList()
        {
            return _helicopterList;
        }

        private void OnCollisionEnter(IHelicopter helicopter, Collision collision)
        {
            if (collision.collider.CompareTag(GameTags.BULLET))
            {
                helicopter.health -= collision.gameObject.GetComponent<BulletBehaviour>().bullet.model.damage;
                if (helicopter.health <= 0)
                {
                    helicopter.view.helicopterBehaviour.actionOnColliderEnter -= OnCollisionEnter;
                    _helicopterList.Remove(helicopter);
                    _helicopterFactory.Destroy(helicopter);
                }
            }
        }
    }
}
