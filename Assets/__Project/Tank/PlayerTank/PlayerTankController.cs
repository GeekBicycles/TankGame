using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankController : IUpdate, IPlayerTankController
    {
        //[SerializeField] public CharacterData _data;
        //private CharacterController _charControler;
        private IInputData inputData;
        private IBulletController bulletController;
        private IPlayerTank playerTank;
        private IPlayerTankFactory playerTankFactory;

        public PlayerTankController(IInputData inputData, IBulletController bulletController)
        {
            this.inputData = inputData;
            this.bulletController = bulletController;
            this.playerTankFactory = new PlayerTankFactory();
            this.playerTank = playerTankFactory.GetPlayerTank(Vector3.zero, Quaternion.identity);

        }

        public IPlayerTank GetPlayerTank()
        {
            return playerTank;
        }

        public void Update(float deltaTime)
        {
            float z = (inputData.up ? 1 : 0) - (inputData.down ? 1 : 0);
            Vector3 movement = new Vector3(0, 0, z);
           //movement = Vector3.ClampMagnitude(movement, playerTank.model.speed);
            movement.y = playerTank.model.gravity;
            movement *= Time.deltaTime * playerTank.model.speed;
            Debug.Log(movement);
            playerTank.view.transform.Translate(movement);
            //_charControler.Move(movement);
            //To do

            playerTank.model.timeToFire += deltaTime;
            if (playerTank.model.timeToFire >= playerTank.model.maxTimeToFire)
            {
                if (inputData.fire)
                {
                    playerTank.model.timeToFire = 0;
                    bulletController.Fire(playerTank.view.bulletSpawnTransform.position, playerTank.view.bulletSpawnTransform.rotation, 500f);
                }
            }
            
        }

    }
}
