using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Agent
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int _initialHealth;
        [SerializeField] private Image _healthBar;
        [SerializeField] private Color[] _colors;

        private int _currentHealth = 0;

        public void Configure()
        {
            GetHealth(_initialHealth);
        }

        public void GetHealth(int healthAmountRecovery)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + healthAmountRecovery, 0, 100);

            _healthBar.DOFillAmount(_currentHealth / 100.0f, 0.1f) ;
            _healthBar.fillAmount = _currentHealth / 100.0f;
            
            UpdateHealthBarColor();
        }

        private void UpdateHealthBarColor()
        {
            _healthBar.color = _currentHealth switch
            {
                <= 25 => _colors[0],
                <= 50 => _colors[1],
                <= 100 => _colors[2],
                _ => _healthBar.color
            };
        }
    }
}
