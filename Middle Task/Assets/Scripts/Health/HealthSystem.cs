using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Health
{
    public class HealthSystem : MonoBehaviour
    {
        public event Action OnDeath;
        [SerializeField] private int MaxHealth = 100;
        [SerializeField] private TextMeshProUGUI _healthUI;
        [SerializeField] private Image _hp;
        private int CurrentHealth;

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
            if (_healthUI != null && _hp != null) 
            {
                _healthUI.text = CurrentHealth.ToString();
                float fillAmoutn = (float)CurrentHealth / MaxHealth;
                _hp.fillAmount = fillAmoutn;
            }
        }

        public void Die()
        {
            if (CurrentHealth <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}