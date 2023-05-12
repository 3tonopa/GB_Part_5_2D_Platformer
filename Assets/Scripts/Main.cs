using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
public class Main : MonoBehaviour
{
    [SerializeField] private LevelObjectView _playerView;
    private AnimationConfig _config;
    private SpriteAnimatorController _playerAnimator;

    void Awake()
    {
        _config = Resources.Load<AnimationConfig>("SpriteAnimCfg");
        _playerAnimator = new SpriteAnimatorController(_config);
        _playerAnimator.StartAnimation(_playerView._spriteRendrerer, AnimState.Run, true,10);
    }
    
    void Update()
    {
        _playerAnimator.Update();
    }
}
}