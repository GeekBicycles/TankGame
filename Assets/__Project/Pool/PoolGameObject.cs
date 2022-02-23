using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class PoolGameObject : IDisposable, IPoolGameObject
    {
        private Stack<GameObject> _stack;
        protected GameObject _prefab;
        private Transform _root;
        protected string _prefabGameName;

        public PoolGameObject(GameObject prefab, string prefabGameName, string poolName)
        {
            _prefab = prefab;
            _prefabGameName = prefabGameName;

            _stack = new Stack<GameObject>();
            _root = new GameObject(poolName).transform;
        }

        protected virtual GameObject InstantiatePrefab()
        {
            GameObject gameObject = GameObject.Instantiate(_prefab);
            gameObject.name = _prefabGameName;
            return gameObject;
        }

        public GameObject Pop()
        {
            GameObject gameObject;
            if (_stack.Count == 0)
            {
                gameObject = InstantiatePrefab();
            }
            else
            {
                gameObject = _stack.Pop();
            }

            gameObject.SetActive(true);
            gameObject.transform.SetParent(null);

            return gameObject;
        }

        public void Push(GameObject gameObject)
        {
            _stack.Push(gameObject);
            gameObject.transform.SetParent(_root);
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            while (_stack.Count > 0)
            {
                GameObject gameObject = _stack.Pop();
                GameObject.Destroy(gameObject);
            }
            GameObject.Destroy(_root.gameObject);
        }
    }
}
