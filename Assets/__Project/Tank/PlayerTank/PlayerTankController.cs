using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankController : IUpdate, IPlayerTankController
    {
        private IInputData inputData;
        private IBulletController bulletController;
        private IPlayerTank playerTank;
        private IPlayerTankFactory playerTankFactory;
        private IMoveController moveController;
        private IFireController fireController;
        private IRotateController rotateController;
        private IBulletPowerFire bulletPowerFire;

        public PlayerTankController(IInputData inputData, IBulletController bulletController)
        {
            this.inputData = inputData;
            this.bulletController = bulletController;
            playerTankFactory = new PlayerTankFactory();
            playerTank = playerTankFactory.GetPlayerTank(Vector3.zero, Quaternion.identity);
            //moveController = new MoveController(inputData, this.playerTank);
            //fireController = new FireController(playerTank, inputData, bulletController);
            //rotateController = new RotateController(playerTank, inputData);
            //this.playerTankFactory = new PlayerTankFactory();
            //this.playerTank = playerTankFactory.GetPlayerTank(Vector3.zero, Quaternion.identity);
            bulletPowerFire = new BulletPowerFire(inputData);

        }

        public IPlayerTank GetPlayerTank()
        {
            return playerTank;
        }

        public void Update(float deltaTime)
        {

            bulletPowerFire.Update(deltaTime);

            float z = (inputData.up ? 1 : 0) - (inputData.down ? 1 : 0);
            Vector3 movement = new Vector3(0, 0, z);
            //movement = Vector3.ClampMagnitude(movement, playerTank.model.speed);
            movement.y = playerTank.model.gravity;
            movement *= Time.deltaTime * playerTank.model.speed;
            //Debug.Log(movement);
            playerTank.view.transform.Translate(movement);
            //_charControler.Move(movement);
            float y = (inputData.left ? 1 : 0) - (inputData.right ? 1 : 0);
            playerTank.view.transform.Rotate(0,y,0);

            //To do

            playerTank.timeToFire += deltaTime;
            if (playerTank.timeToFire >= playerTank.model.maxTimeToFire)
            {
                if (bulletPowerFire._isBulletReady)
                {
                    bulletPowerFire._isBulletReady = false;
                    playerTank.timeToFire = 0;
                    bulletController.Fire(playerTank.view.bulletSpawnTransform.position, playerTank.view.bulletSpawnTransform.rotation, bulletPowerFire.GetFirePower()*500f);
                }
            }
            
            //moveController.Move(deltaTime);
            //rotateController.Rotate(deltaTime);
            //fireController.FireControl(deltaTime);
        }

    }
}
