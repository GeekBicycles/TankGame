using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameStarter : MonoBehaviour
{
    private UpdateController updateController;
    private void Start()
    {
        GameInitialiazation gameInitialiazation= new GameInitialiazation();
        gameInitialiazation.Start(this);
    }

    public void SetUpdateController(UpdateController updateController)
    {
        this.updateController = updateController;
    }

    private void Update()
    {
        updateController.Update(Time.deltaTime);
        updateController.UnscaledUpdate(Time.unscaledDeltaTime);
    }

    private void FixedUpdate()
    {
        updateController.FixedUpdate(Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        updateController.LateUpdate(Time.deltaTime);
    }

}
