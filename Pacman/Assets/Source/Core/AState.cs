using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AState 
{
    public void Enter();
    public void Exit();
    public void Update();
}
