using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private PlayerView playerView;
    private PlayerController _playerController;
    [SerializeField] private InputListener inputListener;

    private void Start()
    {
        _playerController=new PlayerController(playerView);
        inputListener.Construct(_playerController);
    }
}
