using System;
using Health;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private int _damage = 10;
        
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<CharacterBehaviour>())
            {
                _healthSystem.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}