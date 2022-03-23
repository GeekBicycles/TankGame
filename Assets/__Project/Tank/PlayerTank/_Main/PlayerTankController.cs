using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankController : IUpdate, IPlayerTankController, ITurnBased, IMemento
    {

        public event Action endTurn;

        private IBulletController _bulletController;
        private IBulletPowerFire _bulletPowerFire;
        private IChooseEnemy _chooseEnemy;
        private IChooseTank _chooseTank;
        private IMoveController _moveController;
        private IRotateController _rotateController;
        private IFireController _fireController;
        private IPlayerTankList _playerTankList;
        private IPlayerTankFactory _playerTankFactory;
        private bool _onTurn;
        private bool _isFired;

        private List<PlayerTankMementoList> _playerTankMementos;

        public PlayerTankController(IInputData inputData, IInputMouseData inputMouseData, IPlayerTankList playerTankList, IBulletController bulletController)
        {

            _playerTankMementos = new List<PlayerTankMementoList>();

            _playerTankList = playerTankList;
            if (_playerTankList.playerTanks.Count > 0)
            {
                _playerTankList.current = _playerTankList.playerTanks[0];
            }

            _bulletController = bulletController;
            _bulletPowerFire = new BulletPowerFire(inputData);
            _chooseEnemy = new ChooseEnemy(inputMouseData);
            _chooseEnemy.actionChooseEnemy += RotatePlayerToEnemy;
            _chooseTank = new ChoosePlayerTank(playerTankList);
            _chooseTank.actionChoosePlayer += ChoosePlayerTank;
            _moveController = new MoveController(inputData);
            _rotateController = new RotateController(inputData);
            _fireController = new FireController(_bulletController, _bulletPowerFire);
            _playerTankFactory = new PlayerTankFactory();
            _onTurn = false;
            _isFired = false;

            AddReactionOnBullet();
        }

        public void SaveMemento()
        {
            PlayerTankMementoList playerTankMementoList = new PlayerTankMementoList();

            foreach (IPlayerTank playerTank in _playerTankList.playerTanks)
            {
                PlayerTankMemento playerTankMemento = new PlayerTankMemento();
                playerTankMemento.health = playerTank.health;
                playerTankMemento.position = playerTank.view.transform.position;
                playerTankMemento.rotation = playerTank.view.transform.rotation;
                playerTankMementoList.playerTankMementos.Add(playerTankMemento);

                if (playerTank == _playerTankList.current)
                {
                    playerTankMementoList.current = playerTankMemento;
                }
            }

            _playerTankMementos.Add(playerTankMementoList);
        }

        public void LoadPrev()
        {
            int last = _playerTankMementos.Count - 1;
            LoadMemento(last - 1);
        }

        public void LoadMemento(int index)
        {
            if ((index > _playerTankMementos.Count - 1) || (index < 0))
            {
                return;
            }

            foreach (IPlayerTank playerTank in _playerTankList.playerTanks)
            {
                playerTank.view.playerTankBehavior.actionOnColliderEnter -= OnCollisionEnter;
                playerTank.view.playerTankBehavior.actionOnSetDamage -= SetDamage;
                _playerTankFactory.Destroy(playerTank);
            }

            _playerTankList.playerTanks.Clear();
            _playerTankList.current = null;


            PlayerTankMementoList playerTankMementoList = _playerTankMementos[index];

            foreach (PlayerTankMemento playerTankMemento in playerTankMementoList.playerTankMementos)
            {
                IPlayerTank playerTank = _playerTankFactory.GetPlayerTank(playerTankMemento.position, playerTankMemento.rotation);
                playerTank.health = playerTankMemento.health;
                _playerTankList.playerTanks.Add(playerTank);
                if (playerTankMemento == playerTankMementoList.current)
                {
                    _playerTankList.current = playerTank;
                }
            }

            _playerTankMementos.RemoveAt(_playerTankMementos.Count - 1);

        }


        private void AddReactionOnBullet()
        {
            foreach (IPlayerTank playerTank in _playerTankList.playerTanks)
            {
                playerTank.view.playerTankBehavior.actionOnColliderEnter += OnCollisionEnter;
                playerTank.view.playerTankBehavior.actionOnSetDamage += SetDamage;
            }
        }

        private void SetDamage(IPlayerTank playerTank, float damage)
        {
            playerTank.health -= damage;
            playerTank.view.healthSlider.Value = playerTank.health;
            if (playerTank.health <= 0)
            {
                PlayExplosionParticle(playerTank);

                playerTank.view.playerTankBehavior.actionOnColliderEnter -= OnCollisionEnter;
                playerTank.view.playerTankBehavior.actionOnSetDamage -= SetDamage;
                _playerTankList.Remove(playerTank);
                _playerTankFactory.Destroy(playerTank);
            }
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

        public IPlayerTank GetPlayerTank()
        {
            return _playerTankList.current;
        }


        private bool CheckCurrentTank()
        {
            if (_playerTankList.playerTanks.Count == 0) return false;
            if (_playerTankList.current == null) _playerTankList.current = _playerTankList.playerTanks[0];
            return true;
        }

        public void Update(float deltaTime)
        {
            if (!CheckCurrentTank()) return;

            if (_onTurn)
            {
                _chooseEnemy.Update(deltaTime);
                _chooseTank.Update(deltaTime);
                _bulletPowerFire.Update(deltaTime);
                _moveController.Move(deltaTime, _playerTankList.current);
                _rotateController.Rotate(deltaTime, _playerTankList.current);
                if (!_isFired)
                {
                    _isFired = _fireController.Fire(deltaTime, _playerTankList.current, _bulletPowerFire.GetFirePower() * _playerTankList.current.model.maxBulletSpeed);
                }
                else
                {
                    if (_bulletController.GetCurrentBulletCount() == 0)
                    {
                        EndTurn();
                    }
                }

            }
            else
            {
                _rotateController.Rotate(deltaTime, _playerTankList.current);
            }

            _playerTankList.current.view.fireSlider.Value = _bulletPowerFire.GetPressFire();
        }

        private void OnCollisionEnter(IPlayerTank playerTank, Collision collision)
        {
            if (collision.collider.CompareTag(GameTags.BULLET))
            {
                SetDamage(playerTank, collision.gameObject.GetComponent<BulletBehaviour>().bullet.model.damage);
            }
        }

        private void RotatePlayerToEnemy(Transform enemyTransform)
        {
            _playerTankList.current?.view.transform.LookAt(enemyTransform);
        }
        private void ChoosePlayerTank(IPlayerTank newPlayerTank)
        {
            _playerTankList.current = newPlayerTank;
        }

        //TODO переделать в пул


        private void PlayExplosionParticle(IPlayerTank playerTank)
        {
            var destroyPoint = playerTank.view.transform.position;
            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.EXPLOSION_EFFECT_PREFAB);
            var go = GameObject.Instantiate(prefab, destroyPoint, Quaternion.identity);
            go.GetComponent<ParticleSystem>().Play();
        }
    }
}
