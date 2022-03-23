using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class AttermptsController : IAttemptsController
    {
        #region interface
        public IPlayerTankList playerTankList { get; set; }
        public IEnemyTankList enemyTankList { get; set; }
        public IAttermptsBehavior attermptsBehavior { get; set; }
        public Transform canvasTransform { get; set; }
        #endregion
        private ILevelDataController _levelDataController;
        private IAttermptsData _attermptsData;
        private float _attermptsCount;

        public AttermptsController(IPlayerTankList playerTankList, ILevelDataController levelDataController)
        {
            this.playerTankList = playerTankList;
            _levelDataController = levelDataController;
            IAttermptsdataScene AttermptsdataScene = GameObject.FindObjectOfType<AttermptsdataScene>();
            attermptsBehavior = GameObject.FindObjectOfType<AttermptsBehavior>();
            if (AttermptsdataScene == null)
            {
                GameObject go = new GameObject(SceneObjectNames.ATTERMPTS_DATA_SCENE);
                IAttermptsdataScene newAttermptsDataScene = go.AddComponent<AttermptsdataScene>();
                _attermptsData = new AttermptsData(GameSettings.ATTERMPTS);
                newAttermptsDataScene.attermptsData = _attermptsData;
                
                GameObject.DontDestroyOnLoad(go);
            }
            else
            {
                _attermptsData = AttermptsdataScene.attermptsData;
            }
            _attermptsCount = _attermptsData.Attermpts_count;
            Text();
            counter();
        }
        public void counter()
        {
            if (playerTankList.playerTanks.Count == 0)
            {
                _attermptsData.Attermpts_count -= Time.deltaTime;
                new TankSpawner(playerTankList, enemyTankList).Spawn();
            }
            else if (_attermptsData.Attermpts_count == 0)
            {
                _levelDataController.ResetLevel();
            }
            else if(enemyTankList.enemyTanks.Count == 0)
            {
                _levelDataController.IncrementLevel();
            }
            
        }
        private void Text()
        {
            attermptsBehavior.attempts.text = _attermptsCount.ToString();
        }
    }
}
