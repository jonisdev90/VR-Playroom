using System;
using UnityEngine;

namespace Agent
{
    public class Enemy : MonoBehaviour
    {
        private HealthController _healthController;
        
        private void Awake()
        {
            _healthController = GetComponentInChildren<HealthController>();
        }

        private void Start()
        {
            _healthController.Configure();
        }

        private void OnEnable()
        {
            EventsServices.Instance.OnGetHealth += GetHealth;
        }

        private void OnDisable()
        {
            EventsServices.Instance.OnGetHealth -= GetHealth;
        }

        private void GetHealth(int healthAmountRecovery)
        {
            _healthController.GetHealth(healthAmountRecovery);
        }

        public void GetDamage(int damage)
        {
            _healthController.GetHealth(-damage);
        }
    }
}
