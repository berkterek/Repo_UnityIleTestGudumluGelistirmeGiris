using UnityEngine;
using UnityTddBeginner.Abstracts.ScriptableObjects;

namespace UnityTddBeginner.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Stats",menuName = "Terek Gaming/Stats/Player Stats")]
    public class PlayerStats : ScriptableObject,IPlayerStats
    {
        [Header("Move Information")]
        [SerializeField] float _moveSpeed = 5f;
        
        public float MoveSpeed => _moveSpeed;
    }    
}