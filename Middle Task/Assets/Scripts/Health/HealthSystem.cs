using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Health
{
    public class HealthSystem : MonoBehaviour
    {
        public int MaxHealth = 100;
        public TextMeshProUGUI _healthUI;
        public int CurrentHealth;

        private void Start()
        {
            CurrentHealth = MaxHealth;
            _healthUI.text = CurrentHealth.ToString();
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                Die();
            }
            
            UpdateHealthUI();
        }
        
        private void UpdateHealthUI()
        {
            if (_healthUI != null) // Проверяем, назначен ли UI
            {
                _healthUI.text = CurrentHealth.ToString();
            }
        }

        public void Die()
        {
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}