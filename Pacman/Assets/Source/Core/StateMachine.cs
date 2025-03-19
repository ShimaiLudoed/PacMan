using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StateMachine<T> where T : AState
{
    private Dictionary<Type, T> _states;
    public T CurrentState;

    public StateMachine(IdleState idle, DamageState damage)
    {
        _states = new Dictionary<Type, T>()
            {
                {typeof(IdleState), idle as T },
                {typeof(DamageState), damage as T},
            };
    }

    public void ChangeState<T>()
    {
        //TODO find state of T type in dictionary
        if (CurrentState != null)
        {
            CurrentState.Exit();
        }
        CurrentState = _states[typeof(T)];
        CurrentState.Enter();
    }

    private Type MoveNext()
    {
        int nextId = 0;
        for (int i = 0; i < _states.Count; i++)
        {
            if (_states.Values.ElementAt(i).Equals(CurrentState))
            {
                if (_states.Keys.Count > i + 1)
                {
                    nextId = i + 1;
                }
            }
        }
        return _states.Keys.ElementAt(nextId);
    }

    public void Update()
    {
        CurrentState?.Update();
    }
}