using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
public class Main : MonoBehaviour
{
    [SerializeField] private InteractiveObjectView _playerView;
    [SerializeField] private CannonView _cannonView;
    private PlayerController _playerController;
    private CannonController  _cannonController;
    private EmitterController _emitterController;
    
   

    void Awake()
    {
        _playerController = new PlayerController(_playerView);
        _cannonController = new CannonController(_cannonView._muzzleT, _playerView._transform);
        _emitterController = new EmitterController(_cannonView._bullets, _cannonView._emitterT);
    }
    
    void Update()
    {
       _playerController.Update();
       _cannonController.Update();
       _emitterController.Update();
    }
}
}