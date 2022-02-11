using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnscaledUpdate : IUpdatable
{
    public void UnscaledUpdate(float unscaledDeltaTime);
}
