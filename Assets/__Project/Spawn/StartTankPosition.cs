using UnityEngine;

namespace Tank_Game
{
    public class StartTankPosition : IStartTankPosition
    {
        private GameObject _prefab;
        private IStartupPosition _startupPosition;

        public StartTankPosition()
        {
            _prefab = Resources.Load<GameObject>(ResourcesPathes.TANKS_STARTUP_POSITION);
            _startupPosition = _prefab.GetComponent<IStartupPosition>();
        }

        private void CopyTransformPositionRotation(Transform target, Transform source)
        {
            target.position = source.position;
            target.rotation = source.rotation;
        }

        public void SetStartupPosition(IPlayerTankList playerTankList, IEnemyTankList enemyTankList)
        {
            PlayerTanksSetupStartPosition(playerTankList);
            EnemyTanksSetupStartPosition(enemyTankList);
        }

        private void PlayerTanksSetupStartPosition(IPlayerTankList playerTankList)
        {
            if (playerTankList.playerTanks.Count > 3) return;

            if (playerTankList.playerTanks.Count == 1)
            {
                CopyTransformPositionRotation(playerTankList.playerTanks[0].view.transform, _startupPosition.playerGroup1Tank1);
            }
            else if (playerTankList.playerTanks.Count == 2)
            {
                CopyTransformPositionRotation(playerTankList.playerTanks[0].view.transform, _startupPosition.playerGroup2Tank1);
                CopyTransformPositionRotation(playerTankList.playerTanks[1].view.transform, _startupPosition.playerGroup2Tank2);
            }
            else if (playerTankList.playerTanks.Count == 3)
            {
                CopyTransformPositionRotation(playerTankList.playerTanks[0].view.transform, _startupPosition.playerGroup3Tank1);
                CopyTransformPositionRotation(playerTankList.playerTanks[1].view.transform, _startupPosition.playerGroup3Tank2);
                CopyTransformPositionRotation(playerTankList.playerTanks[2].view.transform, _startupPosition.playerGroup3Tank3);
            }

        }

        private void EnemyTanksSetupStartPosition(IEnemyTankList enemyTankList)
        {
            if (enemyTankList.enemyTanks.Count > 3) return;

            if (enemyTankList.enemyTanks.Count == 1)
            {
                CopyTransformPositionRotation(enemyTankList.enemyTanks[0].view.transform, _startupPosition.enemyGroup1Tank1);
            }
            else if (enemyTankList.enemyTanks.Count == 2)
            {
                CopyTransformPositionRotation(enemyTankList.enemyTanks[0].view.transform, _startupPosition.enemyGroup2Tank1);
                CopyTransformPositionRotation(enemyTankList.enemyTanks[1].view.transform, _startupPosition.enemyGroup2Tank2);
            }
            else if (enemyTankList.enemyTanks.Count == 3)
            {
                CopyTransformPositionRotation(enemyTankList.enemyTanks[0].view.transform, _startupPosition.enemyGroup3Tank1);
                CopyTransformPositionRotation(enemyTankList.enemyTanks[1].view.transform, _startupPosition.enemyGroup3Tank2);
                CopyTransformPositionRotation(enemyTankList.enemyTanks[2].view.transform, _startupPosition.enemyGroup3Tank3);
            }

        }


    }
}
