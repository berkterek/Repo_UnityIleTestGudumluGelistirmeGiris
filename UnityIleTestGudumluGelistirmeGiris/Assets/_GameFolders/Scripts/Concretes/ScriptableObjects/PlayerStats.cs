using UnityEngine;
using UnityTddBeginner.Abstracts.ScriptableObjects;

namespace UnityTddBeginner.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Stats",menuName = "Terek Gaming/Stats/Player Stats")]
    public class PlayerStats : Stats,IPlayerStats
    {
        [SerializeField] float _jumpForce = 15000f;
        public float JumpForce => _jumpForce;
    }
}