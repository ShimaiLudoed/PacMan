using InputSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private PlayerMove playerView;
    //TODO: validation for interface implementation or use another field type
    [SerializeField] private InputListener inputListener;  
    private PlayerController _playerController;

    private void Awake()
    {
        Debug.Log("START!");
        _playerController = new (playerView, inputListener);
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
    }
}
