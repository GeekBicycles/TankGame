using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankController : IUpdate
    {
        [SerializeField] public CharacterData _data;
        private CharacterController _charControler;
        private IInputData inputData;
        private ITank tank;

        public PlayerTankController(IInputData inputData, ITank tank, BulletFactory bulletFactory)
        {
            this.inputData = inputData;
            this.tank = tank;
        }
        public void Update(float deltaTime)
        {
            Vector3 movement = new Vector3(inputData.up ? 1 : 0, 0, inputData.down ? 1 : 0);
            movement = Vector3.ClampMagnitude(movement, _data.Speed);
            movement.y = _data.gravity;
            movement *= Time.deltaTime;
            movement = tank.transform.TransformDirection(movement);
            _charControler.Move(movement);
        }
    }
}
