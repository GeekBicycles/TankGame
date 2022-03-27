using UnityEngine;

namespace Tank_Game
{
    public sealed class FireGun : IFireGun
    {
        private const float LINE_LIFE_TIME = 0.1f;

        private GameObject _prefab;
        private Transform _source;
        private float _distance;
        private float _spread;

        public FireGun(Transform transform, float distance, float spread)
        {
            _prefab = Resources.Load<GameObject>(ResourcesPathes.GUN_LINE);
            _source = transform;
            _distance = distance;
            _spread = spread;
        }

        public bool Fire(out RaycastHit hitInfo)
        {

            bool returnValue;

            GameObject gameObject = GameObject.Instantiate(_prefab);
            LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();

            float leftRightCorrection = (Random.value - 0.5f) * _spread;
            float upDownCorrection = (Random.value - 0.5f) * _spread;

            Vector3 target = (_source.forward + _source.right * leftRightCorrection + _source.up * upDownCorrection).normalized;

            if (Physics.Raycast(_source.position, target, out hitInfo, _distance))
            {
                lineRenderer.SetPosition(0, _source.position);
                lineRenderer.SetPosition(1, hitInfo.point);
                returnValue = true;
            }
            else
            {
                lineRenderer.SetPosition(0, _source.position);
                lineRenderer.SetPosition(1, _source.position + target * _distance);
                returnValue = false;
            }

            GameObject.Destroy(gameObject, LINE_LIFE_TIME);

            return returnValue;
        }
    }
}

