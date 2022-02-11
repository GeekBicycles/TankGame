using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFixedUpdate : IUpdatable
{
    public void FixedUpdate(float fixedDeltaTime);
}
