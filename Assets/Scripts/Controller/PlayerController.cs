using UnityEngine;
namespace Platformer
{
    public class PlayerController
    {
        private AnimationConfig _config;
        private SpriteAnimatorController _playerAnimator;
        private LevelObjectView _playerView;
        private ContactPuller _contactPuller;
        private Transform _playerT;
        private Rigidbody2D _rb;
        private float _xAxixInput;
        private float _xVelocity = 0;
        private bool _isJump;
        private float _walkSpeed = 1.5f;
        private float _animationSpeed = 10f;
        private float _movingThreshold = 0.1f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private bool _isMoving;
        private float _jumpForce = 8f;
        private float _jumpTreshold = 1f;
        private float _yVelocity;
        public PlayerController(LevelObjectView player)
        {
           
            _playerView = player;
            _playerT = player.transform;
            _rb = _playerView._rb;

            _config = Resources.Load<AnimationConfig>("SpriteAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_config);
            _playerAnimator.StartAnimation(player._spriteRendrerer, AnimState.Run, true, _animationSpeed);
            _contactPuller = new ContactPuller(_playerView._collider);

        }
        private void MoveTowards()
        {
            _xVelocity += Time.fixedDeltaTime * _walkSpeed * (_xAxixInput < 0 ? -1 : 1);
            _rb.velocity = new Vector2(_xVelocity, _yVelocity);
            _playerT.localScale = _xAxixInput < 0 ? _leftScale : _rightScale;
        }

        public void Update()
        {
            _playerAnimator.Update();
            _contactPuller.Update();
            _xAxixInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            _yVelocity = _rb.velocity.y;
            _isMoving = Mathf.Abs(_xAxixInput) > _movingThreshold;

            _playerAnimator.StartAnimation(_playerView._spriteRendrerer, _isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);

            if (_isMoving)
            {
                MoveTowards();
            }
            else
            {
                _xVelocity = 0;
                _rb.velocity = new Vector2(_xVelocity, _rb.velocity.y);
            }

            if (_contactPuller.IsGrounded)
            {
                if (_isJump && _yVelocity <= _jumpTreshold)
                {
                    _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (Mathf.Abs(_yVelocity) > _jumpTreshold)
                {
                    _playerAnimator.StartAnimation(_playerView._spriteRendrerer, AnimState.Jump, true, _animationSpeed);
                }
            }

        }
    }
}
