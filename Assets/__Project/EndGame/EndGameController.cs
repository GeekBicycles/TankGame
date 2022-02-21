using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tank_Game
{
    public class EndGameController
    {
        private IEndGameModel _endGameModel;
        private IEndGameView _endGameView;
        public EndGameController(bool winOrLose)
        {
            var prefab = Resources.Load<GameObject>(ResourcesPathes.END_GAME_CANVAS);
            var canvas = GameObject.Instantiate(prefab);
            _endGameView = canvas.GetComponent<EndGameView>();
            _endGameModel = new EndGameModel();
            _endGameView.SetText(winOrLose ? _endGameModel.WinGame : _endGameModel.LoseGame);
            _endGameView.OnRestartButtonClick += Restart;
            Time.timeScale = 0;
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
