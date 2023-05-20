using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
public class Main : MonoBehaviour
{
    [SerializeField] private LevelObjectView _playerView;
    [SerializeField] private CannonView _cannonView;
    private PlayerController _playerController;
    private CannonController  _cannonController;
    
   

    void Awake()
    {
        _playerController = new PlayerController(_playerView);
        _cannonController = new CannonController(_cannonView._muzzleT, _playerView._transform);
    }
    
    void Update()
    {
       _playerController.Update();
       _cannonController.Update();
    }
}
}