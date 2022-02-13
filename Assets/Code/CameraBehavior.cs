using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class CameraBehavior : MonoBehaviour
    {
        public Vector3 camOffset = new Vector3(-15f, 20f, -25f);
        private Transform target;
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        void LateUpdate()
        {
            transform.position = target.TransformPoint(camOffset);
            transform.LookAt(target);
        }
    }
}