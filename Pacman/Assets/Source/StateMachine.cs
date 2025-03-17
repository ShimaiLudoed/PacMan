using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
  public AState CurrentState;
  
  public void ChangeState(AState newState)
  {
    if (CurrentState != null)
    {
      CurrentState.Exit();
    }
    CurrentState = newState;
    CurrentState.Enter();
  }

  public void Update()
  {
    CurrentState?.Update();
  }
}
