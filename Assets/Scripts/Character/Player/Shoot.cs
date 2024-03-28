using System;
using System.Collections.Generic;
using InGameObjects.Bullets;
using TMPro;
using UnityEngine;

namespace Character.Player
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _playerRb;
        [SerializeField] private Transform _firePoint;
        private float _timer; 
        [SerializeField] private Rigidbody2D _bulletPrefab;
        private float _bulletsAmount = 30;
        private float _fireRate = 1f;
        private bool _isReloaded;
        [SerializeField] private TextMeshProUGUI _textBulletsAmount;

        private void Start()
        {
            _textBulletsAmount.text = _bulletsAmount + "/30";
        }

        public void Fire()
        {
            
            if (CanFire() & _bulletsAmount != 0)
            {
                Shot();
                _timer = Time.time + _fireRate;
            }
            else if(_bulletsAmount == 0)
            {
                Debug.Log("reloading!!!");
                _bulletsAmount = 5;
                _textBulletsAmount.text = _bulletsAmount + "/30";
            }
        }
        
        private bool CanFire()
        {
            return Time.time > _timer;
        }

        private void Reloading()
        {
             
        }
        private void Shot()
        {
            
            
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerRb.transform.position, 10f);
            List<Transform> enemies = new List<Transform>();
            
            if (colliders != null)
            {
                foreach (var col in colliders)
                {
                    var charact = col.GetComponent<Character>();
                    if (charact != null)
                    {
                        if (charact.GetCharactertype() == CharacterType.Enemy)
                        {
                            if (!charact.IsEnemyDead())
                            {
                                enemies.Add(col.gameObject.transform);
                            }
                            
                        }
                    }
                }
            }
            if (enemies.Count != 0)
            {
                var closestEnemy = GetClosestEnemy(enemies);
                Vector3 dir = closestEnemy.position - _firePoint.transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                var bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.Euler(0f, 0f, angle));
                var bulletProj = bullet.GetComponent<BulletAk74>();
                bulletProj.GetDirection(dir);
                _bulletsAmount--;
                _textBulletsAmount.text = _bulletsAmount + "/30";
            }
            
        }
        
        private Transform GetClosestEnemy(List<Transform> enemies)
        {
            float minDistance = Mathf.Infinity;

            Transform closestEnemy = null;
            foreach (var enemy in enemies)
            {
                float enemyDistance = Vector3.Distance(_playerRb.transform.position, enemy.transform.position);
                if (enemyDistance < minDistance)
                {
                    closestEnemy = enemy;
                    minDistance = enemyDistance;
                }
            }
            
            return closestEnemy;
        }
        
    }
}
