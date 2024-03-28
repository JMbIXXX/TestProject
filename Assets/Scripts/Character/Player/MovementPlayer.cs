using UnityEngine;

namespace Character.Player
{
    public class MovementPlayer : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _playerRb;
         private float _movementSpeed;
        private float _speedLimit = 0.7f;
        private Vector2 _movement;
        private InputsPlayer _inputsPlayer;


        private void Awake()
        {
            _inputsPlayer = GetComponent<InputsPlayer>();
            _movementSpeed = GetComponent<Character>().GetMovementSpeed();
            

        }

        private void Update()
        {
            _movement.x = _inputsPlayer.Horizontal;
            _movement.y = _inputsPlayer.Vertical;
        }

        private void FixedUpdate()
        {
            if (_movement.x != 0 || _movement.y != 0)
            {
                if (_movement.x != 0 && _movement.y != 0)
                {
                    _movement.x *= _speedLimit;
                    _movement.y *= _speedLimit;
                }

                _playerRb.velocity = new Vector2(_movement.x * _movementSpeed, _movement.y * _movementSpeed);
            }
            else
            {
                _playerRb.velocity = new Vector2(0f, 0f);
            }
        }
    }
}
