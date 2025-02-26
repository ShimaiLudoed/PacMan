using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    private InputListener _listener;
    private readonly PlayerMove _playerMove;

    public PlayerController(PlayerMove playerMove, InputListener listener)
    {
        _listener = listener;  
        _playerMove = playerMove;
    }
}
