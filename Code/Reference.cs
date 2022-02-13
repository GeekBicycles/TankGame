using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Tank_Game
{


    public sealed class Reference 
    {
        private GameObject _player;
        private GameObject _enemy;
        private Canvas _mainCanvas;
        private Button _restartButton;
        private EventSystem _eventSystem;


        public GameObject Player
        {
            get
            {
                if (_player == null)
                {
                    var player = Resources.Load<GameObject>("Prefabs/Tank");
                    _player = Object.Instantiate(player);
                }
                return _player;
            }
        }
        public GameObject Enemy
        {
            get
            {
                if (_enemy == null)
                {
                    var enemy = Resources.Load<GameObject>("Prefabs/enemyTank");
                    _enemy = Object.Instantiate(enemy);
                }
                return _enemy;
            }
        }
        public Canvas MainCanvas
        {
            get
            {
                if (_mainCanvas == null)
                {
                    var canvas = Resources.Load<Canvas>("UI/MainCanvas");
                    _mainCanvas = Object.Instantiate(canvas);
                }
                return _mainCanvas;
            }
        }
        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/ResetButton");
                    _restartButton = Object.Instantiate(gameObject, MainCanvas.transform);
                    
                }
                return _restartButton;
            }
        }
        public EventSystem EventSystem
        {
            get
            {
                if (_eventSystem == null)
                {
                    var gameObject = Resources.Load<EventSystem>("UI/EventSystem");
                    _eventSystem = Object.Instantiate(gameObject);
                }
                return _eventSystem;

            }

        }

    }
}
