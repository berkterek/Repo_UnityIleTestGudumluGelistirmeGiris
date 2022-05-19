using UnityEngine;
using UnityTddBeginner.Abstracts.ScriptableObjects;

namespace UnityTddBeginner.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Stats",menuName = "Terek Gaming/Stats/Player Stats")]
    public class PlayerStats : ScriptableObject,IPlayerStats
    {
        [Header("Move Information")]
        [SerializeField] float _moveSpeed = 5f;

        [Header("Combat Info")] 
        [SerializeField] int _maxHealth = 10;
        
        
        public float MoveSpeed => _moveSpeed;
        public int MaxHealth => _maxHealth;
    }    
}