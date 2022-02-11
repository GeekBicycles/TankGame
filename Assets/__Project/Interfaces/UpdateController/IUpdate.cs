using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdate : IUpdatable
{
    public void Update(float deltaTime);
        
}
