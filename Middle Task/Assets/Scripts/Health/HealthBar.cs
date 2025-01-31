using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Health
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _hp;
        [SerializeField] private HealthSystem _healthSystem;
        
        
        void UpdateHealthUI(int currentHealth)
        {
            float fillAmount = (float)currentHealth / _healthSystem.MaxHealth;
            _hp.fillAmount = fillAmount;
        }
    }
}