using UnityEngine;

namespace Tank_Game
{
    public sealed class EnemyTankController : IUpdate, IEnemyTankController
    {
        private IEnemyTankList _enemyTankList;
        private IEnemyTankFactory _enemyTankFactory;

        public EnemyTankController(IEnemyTankList enemyTankList)
        {
            _enemyTankList = enemyTankList;
            _enemyTankFactory = new EnemyTankFactory();
        }

        public IEnemyTankList GetEnemyTankList()
        {
            return _enemyTankList;
        }

        private void OnCollisionEnter(IEnemyTank enemyTank, Collision collision)
        {
            if (collision.collider.CompareTag(GameTags.BULLET))
            {
                enemyTank.view.enemyTankBehaviour.actionOnColliderEnter -= OnCollisionEnter;
                _enemyTankList.enemyTanks.Remove(enemyTank);
                _enemyTankFactory.Destroy(enemyTank);
            }
        }

        public void Update(float deltaTime)
        {

        }
    }
}
