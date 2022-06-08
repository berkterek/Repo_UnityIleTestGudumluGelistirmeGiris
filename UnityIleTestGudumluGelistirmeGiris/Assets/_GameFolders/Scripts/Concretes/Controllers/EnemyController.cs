using UnityEngine;
using UnityTddBeginner.Abstracts.Combats;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.ScriptableObjects;
using UnityTddBeginner.Combats;
using UnityTddBeginner.ScriptableObjects;

namespace UnityTddBeginner.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] EnemyStats _stats;
        
        public IAttacker Attacker { get; set; }
        public IEnemyStats Stats => _stats;
        public IHealth Health { get; private set; }

        void Awake()
        {
            Attacker = new Attacker(Stats);
            Health = new Health(_stats);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out IPlayerController playerController))
            {
                if (other.contacts[0].normal.y < 0f) return;
                
                playerController.Health.TakeDamage(Attacker);
            }
        }
    }
}