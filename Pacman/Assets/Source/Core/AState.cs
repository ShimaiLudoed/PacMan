using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AState 
{
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
