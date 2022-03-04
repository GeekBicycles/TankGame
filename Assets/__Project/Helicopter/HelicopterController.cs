using System;
using UnityEngine;

namespace Tank_Game
{
    public class HelicopterController : IUpdate, IHelicopterController, ITurnBased
    {

        public event Action endTurn;

        private IHelicopterList _helicopterList;
        private IHelicopterFactory _helicopterFactory;
        private ISmoothRouter _router;
        private IHelicopterMoveController _moveController;
        private ITwinController _upTwinController;
        private ITwinController _downTwinController;
        private IFireGunSeries _fireGunSeries;
        private IPlayerTankList _targets;
        private Transform _bulletSpawnTransform;

        private bool _onTurn;
        private bool _isFired;

        public HelicopterController(IHelicopterList helicopterList)
        {
            _helicopterList = helicopterList;
            _helicopterFactory = new HelicopterFactory();
            _targets = null;

            IHelicopter currentHelicopter = _helicopterList.current;
            IHelicopterModel model = currentHelicopter.model;

            AddReactionOnBullet();

            GameObject helicopterRoute = Resources.Load<GameObject>(ResourcesPathes.HELICOPTER_ROUTE_POINTS);
            ITransformPointList transformPointList = helicopterRoute.GetComponent<ITransformPointList>();
            float moveSpeed = model.moveSpeed;
            float rotateSpeed = model.rotateSpeed;
            _router = new SmoothRouter(transformPointList, currentHelicopter.view.transform, moveSpeed, rotateSpeed);
            _moveController = new HelicopterMoveController(currentHelicopter.view.transform, moveSpeed, rotateSpeed);

            _upTwinController = new TwinController(currentHelicopter, currentHelicopter.view.twin1, false);
            _upTwinController.SetTwinSpeed(model.maxTwinSpeed);
            _downTwinController = new TwinController(currentHelicopter, currentHelicopter.view.twin2, true);
            _downTwinController.SetTwinSpeed(model.maxTwinSpeed);

            _bulletSpawnTransform = currentHelicopter.view.bulletSpawnTransform;

            _fireGunSeries = new FireGunSeries(_bulletSpawnTransform, model.fireDistance, model.fireSpread, model.shootPerSec);
            _fireGunSeries.SetActionDamage(SetActionDamageTarget);
            _fireGunSeries.SetActionEndShooting(SetActionEndShooting);

            _onTurn = false;
            _isFired = false;
        }

        public void SetTargets(IPlayerTankList playerTankList)
        {
            _targets = playerTankList;
        }

        private void LookAtTarget()
        {
            if (_targets.playerTanks.Count == 0) return;

            int randomIndex = UnityEngine.Random.Range(0, _targets.playerTanks.Count);
            Transform target = _targets.playerTanks[randomIndex].view.transform;

            _bulletSpawnTransform.LookAt(target);
        }

        public void StartTurn()
        {
            _onTurn = true;
            _isFired = false;
        }

        private void EndTurn()
        {
            _onTurn = false;
            _isFired = false;
            endTurn?.Invoke();
        }

        private void SetActionDamageTarget(RaycastHit raycastHit)
        {
            IDamagable damagable = raycastHit.collider.GetComponentInParent<IDamagable>();
            damagable?.SetDamage(_helicopterList.current.model.damage);
        }

        private void SetActionEndShooting()
        {
            endTurn();
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
            _fireGunSeries.Update(deltaTime);
            _upTwinController.Update(deltaTime);
            _downTwinController.Update(deltaTime);
            bool twinsSpeedReached = _upTwinController.SpeedReached() && _downTwinController.SpeedReached();
            if (twinsSpeedReached)
            {
                _router.Update(deltaTime);
                _moveController.SetDestination(_router.GetTarget());
                _moveController.Update(deltaTime);
            }

            if (_onTurn)
            {
                if (!twinsSpeedReached || !_moveController.OnPosition() || _targets == null || _targets.playerTanks.Count == 0)
                {
                    EndTurn();
                    return;
                }

                if (!_isFired)
                {
                    LookAtTarget();
                    _isFired = true;
                    _fireGunSeries.SetFire(true, _helicopterList.current.model.shootCountPerSeries);
                }
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
