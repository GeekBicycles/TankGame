using UnityEngine;

namespace Tank_Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] public CharacterData _data;
        private CharacterController _charControler;
        // public Rigidbody _rigidbody;

        private void Start()
        {
            _charControler = GetComponent<CharacterController>();
        }
        void Update()
        {
            float deltaX = Input.GetAxis("Horizontal") * _data.Speed;
            float deltaZ = Input.GetAxis("Vertical") * _data.Speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, _data.Speed);
            movement.y = _data.gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charControler.Move(movement);
        }
    }
}