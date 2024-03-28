using System;
using System.Collections;
using UnityEngine;

namespace Character.Enemy
{
    public class EnemyLogic : MonoBehaviour
    {
        private Vector2 _direction;
        private Rigidbody2D _enemy;
        private Rigidbody2D _player;
        private float _movementSpeed;
        private float _damage;
        private bool _canDamage = true;
        private bool _isTargetFound;
        private void Start()
        {
            _movementSpeed = GetComponent<Character>().GetMovementSpeed();
            _damage = GetComponent<Character>().GetDamage();
            _enemy = GetComponent<Rigidbody2D>();
        }
        private IEnumerator AttackDelay()
        {
            yield return new WaitForSeconds(0.3f);
            _canDamage = true;
        }

        private void Update()
        {
            //if (_isTargetFound) return;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
            if (colliders != null)
            {
                foreach (var col in colliders)
                {
                    var charact = col.GetComponent<Character>();
                    if (charact != null)
                    {
                        if (charact.GetCharactertype() == CharacterType.Player)
                        {
                            _player = charact.GetComponent<Rigidbody2D>();
                            _isTargetFound = true;
                        }
                    }
                }
            }

        }
        private void FixedUpdate()
        {
            if (!_isTargetFound) return;
            _direction =  (_player.transform.position - transform.position).normalized;
            _enemy.velocity = _direction * _movementSpeed;
            //transform.position =
                //Vector2.MoveTowards(transform.position, _player.position, _movementSpeed * Time.fixedDeltaTime);

        }

        private void OnTriggerStay2D(Collider2D col)
        {
            Character target = col.gameObject.GetComponentInChildren<Character>();
            if (target)
            {
                if (target.GetCharactertype() == CharacterType.Player)
                {
                    if (col is BoxCollider2D)
                    {
                        if (_canDamage)
                        {
                            target.TakeDamage(_damage);
                            _canDamage = false;
                            StopAllCoroutines();
                            StartCoroutine(AttackDelay());
                        }
                    }
                }

            }
        }
    }
}
