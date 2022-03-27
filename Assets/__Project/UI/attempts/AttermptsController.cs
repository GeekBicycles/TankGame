using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class AttermptsController : IAttemptsController
    {
        #region interface
        public IPlayerTankList playerTankList;
        private AttermptsBehavior _attermptsBehavior;
        private IAttermptsData _attermptsData;
        #endregion

        public AttermptsController(IPlayerTankList playerTankList)
        {
            this.playerTankList = playerTankList;
            IAttermptsdataScene AttermptsdataScene = GameObject.FindObjectOfType<AttermptsdataScene>();
            
            if (AttermptsdataScene == null)
            {
                GameObject go = new GameObject(SceneObjectNames.ATTERMPTS_DATA_SCENE);
                AttermptsdataScene newAttermptsDataScene = go.AddComponent<AttermptsdataScene>();
                _attermptsData = new AttermptsData(GameSettings.ATTERMPTS);
                newAttermptsDataScene.attermptsData = _attermptsData;
                
                GameObject.DontDestroyOnLoad(go);
            }
            else
            {
                _attermptsData = AttermptsdataScene.attermptsData;
            }
            InitAttermptsDataStartInfoBehaviour();
            TextAttermpts();
        }
        private void InitAttermptsDataStartInfoBehaviour()
        {
            _attermptsBehavior = GameObject.FindObjectOfType<AttermptsBehavior>();
        }
        public void EndEnemyWIN()
        {
            if (playerTankList.playerTanks.Count == 0)
            {
                _attermptsData.Attermpts_count -= 1;
            }
        }
        private void TextAttermpts()
        {
            _attermptsBehavior.attempts.text = _attermptsData.Attermpts_count.ToString();
        }
    }
}

