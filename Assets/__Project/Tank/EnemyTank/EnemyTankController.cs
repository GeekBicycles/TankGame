using UnityEngine;

namespace Tank_Game
{
    public sealed class EnemyTankController : IUpdate, IEnemyTankController, ITurnBased
    {
        private IEnemyTankList _enemyTankList;
        private IEnemyTankFactory _enemyTankFactory;
        private bool _onTurn;

        public EnemyTankController(IEnemyTankList enemyTankList)
        {
            _enemyTankList = enemyTankList;
            _enemyTankFactory = new EnemyTankFactory();
        }

        public void SetOnTurn(bool value)
        {
            _onTurn = value;
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
            if (_onTurn)
            {

            }
            else
            {

            }
        }
    }
}
