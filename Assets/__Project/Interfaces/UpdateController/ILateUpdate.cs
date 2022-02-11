using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILateUpdate : IUpdatable
{
    public void LateUpdate(float deltaTime);

}
