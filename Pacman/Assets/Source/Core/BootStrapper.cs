using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private PlayerMove playerView;
    //TODO: validation for interface implementation or use another field type
    [SerializeField] private InputListener inputListener;  
    private PlayerController _playerController;
    public StateMachine StateMachine;
    private int _index;
    private AState[] _states;

    private void Awake()
    {
        StateMachine = new StateMachine();
        Debug.Log("START!");
        _playerController = new (playerView, inputListener);
        _states = new AState[]
        {

        };
        StateMachine.ChangeState(_states[_index]);
    }

    private void Start()
    {
        Debug.Log("BIND!");
        _playerController.Bind();
    }
    private void OnDisable()
    {
        _playerController.Expose();
    }
    private void Update()
    {
        StateMachine.Update();
    }
}
