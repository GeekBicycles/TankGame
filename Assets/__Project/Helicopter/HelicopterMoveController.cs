using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class HelicopterMoveController : IHelicopterMoveController
    {

        private const float ON_POSITION_DISTANCE = 0.1f;

        private Transform _transform;
        private Transform _target;
        private float _moveSpeed;
        private float _rotationSpeed;

        public HelicopterMoveController(Transform transform, float moveSpeed, float rotationSpeed)
        {
            _transform = transform;
            _target = transform;
            _moveSpeed = moveSpeed;
            _rotationSpeed = rotationSpeed;
        }

        public void SetDestination(Transform transform)
        {
            _target = transform;
        }

        public void Update(float deltaTime)
        {
            Vector3 newPosition = Vector3.Lerp(_transform.position, _target.position, 1f * deltaTime);
            _transform.position = newPosition;

            Quaternion newRotation = Quaternion.Lerp(_transform.rotation, _target.rotation, 1f * deltaTime);
            _transform.rotation = newRotation;
        }

        public bool OnPosition()
        {
            return (_target.position - _transform.position).sqrMagnitude <= ON_POSITION_DISTANCE;
        }
    }
}
