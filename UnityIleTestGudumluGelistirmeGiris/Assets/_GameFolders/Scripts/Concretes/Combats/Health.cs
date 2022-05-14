using UnityEngine;
using UnityTddBeginner.Abstracts.Combats;

namespace UnityTddBeginner.Combats
{
    public class Health : IHealth
    {
        int _currentHealth = 0;

        bool IsDead => _currentHealth <= 0;
        public int CurrentHealth => _currentHealth;
        public event System.Action OnTookDamage;
        public event System.Action OnDead;

        public Health(int maxHealth)
        {
            _currentHealth = maxHealth;
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