using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class PoolGameObject :IDisposable
    {
        private Stack<GameObject> stack;
        private GameObject prefab;
        private Transform root;

        public PoolGameObject(GameObject prefab)
        {
            this.prefab = prefab;

            stack = new Stack<GameObject>();
            root = new GameObject(prefab.name).transform;
        }

        public GameObject Pop()
        {
            GameObject gameObject;
            if (stack.Count == 0)
            {
                gameObject = GameObject.Instantiate(prefab);
                gameObject.name = prefab.name;
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
