using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameInitialiazation
{
    private UpdateController updateController;
    public void Start(GameStarter gameStarter)
    {
        updateController = new UpdateController();
        gameStarter.SetUpdateController(updateController);
    }
}
