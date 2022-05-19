using UnityEngine;
using UnityTddBeginner.Abstracts.Combats;
using UnityTddBeginner.Abstracts.ScriptableObjects;

namespace UnityTddBeginner.Combats
{
    public class Health : IHealth
    {
        int _currentHealth = 0;
        int _maxHealth = 0;

        bool IsDead => _currentHealth <= 0;
        public int CurrentHealth => _currentHealth;
        public event System.Action OnTookDamage;
        public event System.Action OnDead;

        public Health(IStats stats)
        {
            _maxHealth = stats.MaxHealth;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(IAttacker attacker)
        {
            if (IsDead) return;
            
            _currentHealth -= attacker.Damage;
            _currentHealth = Mathf.Max(_currentHealth, 0);
            OnTookDamage?.Invoke();

            if (IsDead)
            {
                OnDead?.Invoke();    
            }
        }
    }
}