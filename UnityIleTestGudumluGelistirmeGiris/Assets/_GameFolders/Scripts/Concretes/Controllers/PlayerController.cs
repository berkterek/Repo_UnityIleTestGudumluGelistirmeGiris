using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Abstracts.ScriptableObjects;
using UnityTddBeginner.Inputs;
using UnityTddBeginner.Movements;
using UnityTddBeginner.ScriptableObjects;

namespace UnityTddBeginner.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] PlayerStats _playerStats;
        
        IMover _mover;
        //Flip
        
        //Jump or Double Jump
        //Attack
        //Health
        //Collect
        //Animation
        public IInputReader InputReader { get; set; }
        public IPlayerStats Stats => _playerStats;

        void Awake()
        {
            InputReader = new InputReader();
            _mover = new PlayerMoveWithTranslate(this);
        }

        void Update()
        {
            _mover.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }    
}