using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private PlayerMove playerView;
    private PlayerController _playerController;
    [SerializeField] private LegacyInputListener inputListener;

    private void Start()
    {
        _playerController=new PlayerController(playerView);
        inputListener.Construct(_playerController);
    }
}
