using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class EnemyTankController : IUpdate, IEnemyTankController
    {
        private IBulletController bulletController;
        private IEnemyTankList enemyTankList;
        private IEnemyTankFactory enemyTankFactory;
        private ITankSpawner tankSpawner;
        private IEnemyMoveController enemyMoveController;

        private int enemyTanksCount = 10;

        public EnemyTankController(IBulletController bulletController)
        {
            this.bulletController = bulletController;

            enemyTankList = new EnemyTankList();
            enemyTankFactory = new EnemyTankFactory();
            tankSpawner = new TankSpawner(enemyTankFactory);
            enemyMoveController = new EnemyMoveController();
        }

        public IEnemyTankList GetEnemyTankList()
        {
            return enemyTankList;
        }

        public void SpawnTanks()
        {
            if (enemyTankList.enemyTanks.Count >= enemyTanksCount) return;
            IEnemyTank enemyTank = tankSpawner.Spawn();
            if (enemyTank == null) return;
            enemyTank.view.enemyTankBehaviour.actionOnColliderEnter += OnCollisionEnter;
            enemyTankList.enemyTanks.Add(enemyTank);
        }

        private void OnCollisionEnter(IEnemyTank enemyTank, Collision collision)
        {
            if (collision.collider.CompareTag(GameTags.bullet))
            {
                enemyTank.view.enemyTankBehaviour.actionOnColliderEnter -= OnCollisionEnter;
                enemyTankList.enemyTanks.Remove(enemyTank);
                enemyTankFactory.Destroy(enemyTank);
            }
        }

        public void Update(float deltaTime)
        {
            SpawnTanks();

            foreach (IEnemyTank enemyTank in enemyTankList.enemyTanks)
            {
                enemyMoveController.Move(enemyTank);
                enemyTank.timeToFire += deltaTime;
                if (enemyTank.timeToFire >= enemyTank.model.maxTimeToFire)
                {
                    enemyTank.timeToFire -= enemyTank.model.maxTimeToFire;
                    bulletController.Fire(enemyTank.view.bulletSpawnTransform.position, enemyTank.view.bulletSpawnTransform.rotation, enemyTank.model.bulletforce);
                }

            }
        }

        private void Pursuit(IEnemyTank enemyTank)
        {
            enemyTank.view.navMeshAgent.SetDestination(enemyTank.view._pursuitPoint.position);
        }
    }
}
