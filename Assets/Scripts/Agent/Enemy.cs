using System;
using UnityEngine;

namespace Agent
{
    public class Enemy : MonoBehaviour
    {
        private DamageController _damageController;
        private HealthController _healthController;
        
        private void Awake()
        {
            _healthController = GetComponentInChildren<HealthController>();
            _damageController = GetComponentInChildren<DamageController>();
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
            if (_healthController == null)
            {
                Debug.LogError("HealthController is null!");
                return;
            }
        
            _healthController.GetHealth(healthAmountRecovery);
        }
    }
}
