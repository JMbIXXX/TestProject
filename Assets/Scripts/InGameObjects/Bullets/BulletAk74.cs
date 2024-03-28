using Character;
using UnityEngine;

namespace InGameObjects.Bullets
{
    public class BulletAk74 : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _projSpeed;
        [SerializeField] private float _projDamage;
        private Vector3 _startPosition;
    
        private void OnEnable()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _startPosition = gameObject.transform.position;

        }

        private void Update()
        {
            if (!IsBulletInRange())
            {
                Destroy(gameObject);
            }
        }

        public void GetDirection(Vector2 direction)
        {
            _rigidbody2D.velocity = direction.normalized * _projSpeed;
        }
    
        protected bool IsBulletInRange()
        {
            var range = gameObject.transform.position - _startPosition;
            return range.sqrMagnitude <= 15 * 15;
        }
        public void OnTriggerEnter2D(Collider2D col)
        {
            var target = col.gameObject.GetComponent<Character.Character>();
            if (target != null)
            {
                if (target.GetCharactertype() == CharacterType.Enemy)
                {
                    if (col.isTrigger)
                    {
                        target.TakeDamage(_projDamage);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}