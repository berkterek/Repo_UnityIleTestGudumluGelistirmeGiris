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
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] PlayerStats _playerStats;
        [SerializeField] Rigidbody2D _rigidbody2D;
        
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
            GetReference();
            InputReader = new InputReader();
            _mover = new PlayerMoveWithTranslate(this);
            _flip = new PlayerFlipWithScale(this);
            Health = new Health(Stats);
            Attacker = new Attacker(Stats);
            JumpManager = new PlayerJumpManager(this, new ForceJumpDal(_rigidbody2D));
        }

        void OnValidate()
        {
            GetReference();
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

        private void GetReference()
        {
            if (_rigidbody2D == null)
            {
                _rigidbody2D = GetComponent<Rigidbody2D>();
            }
        }
    }
}