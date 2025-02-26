using InputSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    private readonly IInputHandler _listener;
    private readonly PlayerMove _playerMove;

    public PlayerController(PlayerMove playerMove, IInputHandler listener)
    {
        _listener = listener;  
        _playerMove = playerMove;
    }

    public void Bind() => _listener.OnMove += _playerMove.Move;
    public void Expose  () => _listener.OnMove -= _playerMove.Move;
}
