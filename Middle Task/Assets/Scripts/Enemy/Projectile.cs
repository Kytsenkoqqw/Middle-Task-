using System;
using System.Collections;
using System.Security.Cryptography;
using Health;
using UnityEngine;

namespace Enemy
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speedProjectile = 3f;
        [SerializeField] private float _waitTime = 3f;
        [SerializeField] private float _waitTimer;
        [SerializeField] private HealthSystem _healthSystem;
        
        private Vector3 _direction;

        public void SetDirection(Vector3 direction)
        {
            _direction = direction.normalized;
        }

        private void Update()
        {
            transform.Translate(_direction * _speedProjectile * Time.deltaTime, Space.World);
            _waitTimer += Time.deltaTime;

            if (_waitTimer >= _waitTime)
            {
                Destroy(gameObject);
                _waitTimer = 0;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<CharacterBehaviour>())
            {
                _healthSystem.TakeDamage(30);
                StartCoroutine(DestroyProjectile());
            }
        }

        private IEnumerator DestroyProjectile()
        {
            yield return null;
            Destroy(gameObject);
        }

    }
}