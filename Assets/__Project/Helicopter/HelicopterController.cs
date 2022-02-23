using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class HelicopterController : IUpdate, IHelicopterController
    {
        private IHelicopterList _helicopterList;
        private IHelicopterFactory _helicopterFactory;

        public HelicopterController(IHelicopterList helicopterList)
        {
            _helicopterList = helicopterList;
            _helicopterFactory = new HelicopterFactory();
            
            AddReactionOnBullet();
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
            return;
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
