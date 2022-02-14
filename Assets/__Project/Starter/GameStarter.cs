using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tank_Game
{
    public sealed class GameStarter : MonoBehaviour
    {
        private IUpdateController mainUpdateController;
        private void Start()
        {
            Game game = new Game();
            game.Start(this);
        }

        public void SetUpdateController(IUpdateController updateController)
        {
            this.mainUpdateController = updateController;
        }

        private void Update()
        {
            mainUpdateController.Update(Time.deltaTime);
            mainUpdateController.UnscaledUpdate(Time.unscaledDeltaTime);
        }

        private void FixedUpdate()
        {
            mainUpdateController.FixedUpdate(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            mainUpdateController.LateUpdate(Time.deltaTime);
        }

    }

}

