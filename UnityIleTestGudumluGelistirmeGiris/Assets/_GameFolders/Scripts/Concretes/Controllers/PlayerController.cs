using UnityEngine;
using UnityTddBeginner.Abstracts.Combats;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Abstracts.ScriptableObjects;
using UnityTddBeginner.Combats;
using UnityTddBeginner.Inputs;
using UnityTddBeginner.Movements;
using UnityTddBeginner.ScriptableObjects;

namespace UnityTddBeginner.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] PlayerStats _playerStats;
        
        IMover _mover;
        IFlip _flip;
        
        //Jump or Double Jump or many many jump
        //Collect
        //Animation
        public IInputReader InputReader { get; set; }
        public IPlayerStats Stats => _playerStats;
        public IHealth Health { get; private set; }
        public IAttacker Attacker { get; private set; }
        public IJumpService JumpManager { get; private set; }

        void Awake()
        {
            InputReader = new InputReader();
            _mover = new PlayerMoveWithTranslate(this);
            _flip = new PlayerFlipWithScale(this);
            Health = new Health(Stats);
            Attacker = new Attacker(Stats);
            JumpManager = new PlayerJumpManager(this, new PlayerForceJumpDal(this));
        }

        void Update()
        {
            _mover.Tick();
            _flip.Tick();
            JumpManager.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
            JumpManager.FixedTick();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            JumpManager.ResetCounter();
            if (other.collider.TryGetComponent(out IEnemyController enemyController))
            {
                if (other.contacts[0].normal.y != 1f) return;
                
                enemyController.Health.TakeDamage(Attacker);
            }
        }
    }
}