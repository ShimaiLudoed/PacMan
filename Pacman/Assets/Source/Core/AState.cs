using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AState : MonoBehaviour
{
  protected StateMachine _stateMachine;

  protected AState(StateMachine stateMachine)
  {
    _stateMachine = stateMachine;
  
  }

  public virtual string GetStateName()
  {
    return GetType().Name; 
  }

  public abstract void Enter();

  public abstract void Exit();

  public abstract void Update();
}
