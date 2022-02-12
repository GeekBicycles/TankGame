using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{


    public class GameController : MonoBehaviour
    {
        private Reference _reference;

        private void Awake()
        {
            _reference = new Reference();
            _reference.Player.gameObject.SetActive(true);
            _reference.EventSystem.gameObject.SetActive(true);
            _reference.MainCanvas.gameObject.SetActive(true);
            RestartButtonAction restart = new RestartButtonAction();
            _reference.RestartButton.onClick.AddListener(restart.RestartGame);
            _reference.RestartButton.gameObject.SetActive(true);
        }


    }
}
