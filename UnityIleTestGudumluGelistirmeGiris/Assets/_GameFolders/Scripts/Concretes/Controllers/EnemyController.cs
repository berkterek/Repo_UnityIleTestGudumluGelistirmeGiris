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

        void Awake()
        {
            Attacker = new Attacker(Stats);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out IPlayerController playerController))
            {
                Debug.Log("Attack to Player");
                playerController.Health.TakeDamage(Attacker);
            }
        }
    }
}