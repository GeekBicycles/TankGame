using System.Collections.Generic;

namespace Tank_Game
{
    public sealed class TurnBasedController
    {
        private ITurnBased _firstTurn;
        private ITurnBased _secondTurn;
        private ITurnBased _thirdTurn;
        private IEnemyTankList _enemyTankList;
        private IMementoController _mementoController;
        private List<IEnemyTank> _enemyTanksToTurn;
        public TurnBasedController(ITurnBased firstTurn, ITurnBased secondTurn, ITurnBased thirdTurn, IEnemyTankList enemyTankList, IMementoController mementoController)
        {
            _firstTurn = firstTurn;
            _secondTurn = secondTurn;
            _thirdTurn = thirdTurn;
            _enemyTankList = enemyTankList;
            _mementoController = mementoController;

            _mementoController.Save();

            _firstTurn.endTurn += FirstTurnEnd;
            _firstTurn.StartTurn();
        }

        private void CreateEnemyTankListToTurn()
        {
            _enemyTanksToTurn = new List<IEnemyTank>();
            _enemyTanksToTurn.AddRange(_enemyTankList.enemyTanks);
        }

        private void FirstTurnEnd()
        {
            _firstTurn.endTurn -= FirstTurnEnd;

            CreateEnemyTankListToTurn();

            EnemyTanksTurn();

        }

        private void EnemyTanksTurn()
        {
            _secondTurn.endTurn -= EnemyTanksTurn;
            if (_enemyTanksToTurn.Count == 0)
            {
                SecondTurnEnd();
                return;
            }

            _enemyTankList.current = _enemyTanksToTurn[0];
            _enemyTanksToTurn.RemoveAt(0);
            _secondTurn.endTurn += EnemyTanksTurn;
            _secondTurn.StartTurn();
        }

        private void SecondTurnEnd()
        {
            _thirdTurn.endTurn += ThirdTurnEnd;
            _thirdTurn.StartTurn();
        }

        private void ThirdTurnEnd()
        {
            _thirdTurn.endTurn -= ThirdTurnEnd;

            _mementoController.Save();

            _firstTurn.endTurn += FirstTurnEnd;
            _firstTurn.StartTurn();
        }
    }
}
