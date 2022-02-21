using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tank_Game
{
    public class EndGameView : MonoBehaviour, IEndGameView
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Text _text;

        public event Action OnRestartButtonClick;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartButton);
        }

        private void RestartButton()
        {
            OnRestartButtonClick?.Invoke();
        }

        public void SetText(string value)
        {
            _text.text = value;
        }
    }
}
