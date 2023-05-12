using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
public class Main : MonoBehaviour
{
    [SerializeField] private LevelObjectView _playerView;
    private PlayerController _playerController;
    
   

    void Awake()
    {
        _playerController = new PlayerController(_playerView);
    }
    
    void Update()
    {
       _playerController.Update();
    }
}
}