using UnityEngine;
using UnityTddBeginner.Abstracts.Combats;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Combats;

namespace UnityTddBeginner.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        public IAttacker Attacker { get; private set; }

        void Awake()
        {
            Attacker = new Attacker();
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