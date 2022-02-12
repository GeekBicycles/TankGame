using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tank_Game
{
    public sealed class RestartButtonAction
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }
    }
}