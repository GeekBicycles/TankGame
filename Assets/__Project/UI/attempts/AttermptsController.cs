using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class AttermptsController : IAttemptsController
    {
        #region interface
        public IPlayerTankList playerTankList;
        public IAttermptsBehavior attermptsBehavior;
        private IAttermptsData _attermptsData;
        #endregion
        private float _attermptsCount;

        public AttermptsController(IPlayerTankList playerTankList)
        {
            this.playerTankList = playerTankList;
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
        }
        public void EndEnemyWIN()
        {
            if (playerTankList.playerTanks.Count == 0)
            {
                _attermptsData.Attermpts_count -= 1;
            }
        }
        private void Text()
        {
            attermptsBehavior.attempts.text = _attermptsCount.ToString();
        }
    }
}
