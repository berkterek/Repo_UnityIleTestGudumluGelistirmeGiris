using UnityEngine;
using UnityEngine.InputSystem;
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
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] PlayerStats _playerStats;
        [SerializeField] Rigidbody2D _rigidbody2D;
        [SerializeField] InputActionReference _movementAction;
        
        IFlip _flip;
        
        public IInputReader InputReader { get; set; }
        public IPlayerStats Stats => _playerStats;
        public IHealth Health { get; private set; }
        public IAttacker Attacker { get; private set; }
        public IJumpService JumpManager { get; private set; }
        public IMovementService MovementManager { get; private set; }

        void Awake()
        {
            GetReference();
            InputReader = new InputReader(_movementAction);
            _flip = new PlayerFlipWithScale(this);
            Health = new Health(Stats);
            Attacker = new Attacker(Stats);
            JumpManager = new PlayerJumpManager(this, new ForceJumpDal(_rigidbody2D));
            MovementManager = new PlayerMovementManager(this, new MoveWithTranslateDal(transform));
        }

        void OnValidate()
        {
            GetReference();
        }

        void Update()
        {
            MovementManager.Tick();
            _flip.Tick();
            JumpManager.Tick();
        }

        void FixedUpdate()
        {
            MovementManager.FixedTick();
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

        private void GetReference()
        {
            if (_rigidbody2D == null)
            {
                _rigidbody2D = GetComponent<Rigidbody2D>();
            }
        }
    }
}