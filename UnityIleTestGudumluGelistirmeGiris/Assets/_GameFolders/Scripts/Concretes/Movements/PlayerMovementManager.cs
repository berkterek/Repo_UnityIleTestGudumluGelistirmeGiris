using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Movements;

namespace UnityTddBeginner.Movements
{
    public class PlayerMovementManager : IMovementService
    {
        readonly IPlayerController _playerController;
        readonly IMoverDal _moverDal;

        float _inputValue;
        
        public PlayerMovementManager(IPlayerController playerController, IMoverDal moverDal)
        {
            _playerController = playerController;
            _moverDal = moverDal;
        }
        
        public void Tick()
        {
            _inputValue = _playerController.InputReader.Horizontal * _playerController.Stats.MoveSpeed * Time.deltaTime;
        }

        public void FixedTick()
        {
            if (_inputValue == 0f) return;
            
            _moverDal.MoveProcess(_inputValue);
        }
    }
}