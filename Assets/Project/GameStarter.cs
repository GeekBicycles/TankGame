using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameStarter : MonoBehaviour
{
    private void Start()
    {
        GameInitialiazation gameInitialiazation= new GameInitialiazation();
        gameInitialiazation.Start(this);
    }
}
