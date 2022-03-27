using UnityEngine;

namespace Tank_Game
{
    public sealed class LevelDataController : ILevelDataController
    {

        private ILevelData _levelData;
        private LevelDataStartInfoBehaviour _levelDataStartInfoBehaviour;

        public LevelDataController()
        {
            ILevelDataScene levelDataScene = GameObject.FindObjectOfType<LevelDataScene>();

            if (levelDataScene == null)
            {
                GameObject go = new GameObject(SceneObjectNames.LEVEL_DATA_SCENE);
                LevelDataScene newLevelDataScene = go.AddComponent<LevelDataScene>();
                _levelData = new LevelData(GameSettings.START_LEVEL);
                newLevelDataScene.levelData = _levelData;
                GameObject.DontDestroyOnLoad(go);
            }
            else
            {
                _levelData = levelDataScene.levelData;
            }
            InitLevelDataStartInfoBehaviour();
            ShowLevelDataStartInfo();
        }

        private void InitLevelDataStartInfoBehaviour()
        {
            _levelDataStartInfoBehaviour = GameObject.FindObjectOfType<LevelDataStartInfoBehaviour>();
        }

        private void ShowLevelDataStartInfo()
        {
            if (_levelDataStartInfoBehaviour == null)
            {
                Debug.Log(ErrorMessages.LEVEL_DATA_START_INFO_BEHAVIOUR_EXPECTED);
                return;
            }

            _levelDataStartInfoBehaviour.levelInfo.text = GameMessages.LEVEL_INFO + _levelData.levelNumber.ToString();

        }

        public void IncrementLevel()
        {
            _levelData.levelNumber++;
        }

        public void ResetLevel()
        {
            _levelData.levelNumber = GameSettings.START_LEVEL;
        }
    }
}
