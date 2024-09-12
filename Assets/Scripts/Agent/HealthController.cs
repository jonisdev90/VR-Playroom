using UnityEngine;
using UnityEngine.UI;

namespace Agent
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int _initialHealth;
        [SerializeField] private Image _healthBar;

        private int _currentHealth = 0;

        private void Start()
        {
            GetHealth(_initialHealth);
        }

        public void GetHealth(int healthAmountRecovery)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + healthAmountRecovery, 0, 100);

            _healthBar.fillAmount = _currentHealth / 100.0f;
        }
    }
}
