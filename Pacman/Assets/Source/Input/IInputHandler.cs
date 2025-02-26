using System;
using UnityEngine;

namespace InputSystem
{
    public interface IInputHandler
    {
        event Action<Vector2> OnMove;
    }
}
