using UnityEngine;

namespace UnityTddBeginner.ScriptableObjects
{
    public abstract class Stats : ScriptableObject
    {
        [Header("Move Information")]
        [SerializeField] protected float _moveSpeed = 5f;

        [Header("Combat Info")] 
        [SerializeField] protected int _maxHealth = 10;
        [SerializeField] protected int _damage = 1;
        
        public float MoveSpeed => _moveSpeed;
        public int MaxHealth => _maxHealth;
        public virtual int CalculateDamage => _damage;
    }
}