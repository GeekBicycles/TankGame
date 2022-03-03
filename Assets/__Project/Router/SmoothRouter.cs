using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class SmoothRouter : ISmoothRouter
    {
        private const float MIN_DISTANCE = 0.1f;

        private GameObject _gameObject;
        private IRouter _router;
        private Transform _target;
        private float _moveSpeed;
        private float _rotateSpeed;

        public SmoothRouter(ITransformPointList pointList, Transform startPosition, float moveSpeed, float rotateSpeed)
        {
            _gameObject = new GameObject(SceneObjectNames.HELICOPTER_SMOOTH_TARGET);
            _gameObject.transform.position = startPosition.position;
            _gameObject.transform.rotation = startPosition.rotation;

            _router = new Router(pointList);
            _target = _router.GetNextPoint();
            _moveSpeed = moveSpeed;
            _rotateSpeed = rotateSpeed;
        }

        public void Update(float deltaTime)
        {
            Vector3 newPosition = Vector3.MoveTowards(_gameObject.transform.position, _target.position, _moveSpeed * deltaTime);
            _gameObject.transform.position = newPosition;

            Quaternion newRotation = Quaternion.RotateTowards(_gameObject.transform.rotation, _target.rotation, _rotateSpeed * deltaTime);
            _gameObject.transform.rotation = newRotation;

            if ((_gameObject.transform.position - _target.position).sqrMagnitude < MIN_DISTANCE)
            {
                _target = _router.GetNextPoint();
            }
        }

        public Transform GetTarget()
        {
            return _gameObject.transform;
        }

        public void Dispose()
        {
            GameObject.Destroy(_gameObject);
        }
    }
}
