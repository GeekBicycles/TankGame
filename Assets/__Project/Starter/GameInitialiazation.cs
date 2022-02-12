using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameInitialiazation
{
    private IUpdateController mainUpdateController;
    public void Start(GameStarter gameStarter)
    {
        mainUpdateController = new UpdateController();
        gameStarter.SetUpdateController(mainUpdateController);
    }
}
