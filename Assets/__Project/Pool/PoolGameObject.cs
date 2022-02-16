using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class PoolGameObject : IDisposable, IPoolGameObject
    {
        private Stack<GameObject> stack;
        private GameObject prefab;
        private Transform root;
        private string prefabGameName;

        public PoolGameObject(GameObject prefab, string prefabGameName, string poolName)
        {
            this.prefab = prefab;
            this.prefabGameName = prefabGameName;

            stack = new Stack<GameObject>();
            root = new GameObject(poolName).transform;
        }

        public GameObject Pop()
        {
            GameObject gameObject;
            if (stack.Count == 0)
            {
                gameObject = GameObject.Instantiate(prefab);
                gameObject.name = prefabGameName;
            }
            else
            {
                gameObject = stack.Pop();
            }

            gameObject.SetActive(true);
            gameObject.transform.SetParent(null);

            return gameObject;
        }

        public void Push(GameObject gameObject)
        {
            stack.Push(gameObject);
            gameObject.transform.SetParent(root);
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            while (stack.Count > 0)
            {
                GameObject gameObject = stack.Pop();
                GameObject.Destroy(gameObject);
            }
            GameObject.Destroy(root.gameObject);
        }
    }
}
