using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Movements;

namespace UnityTddBeginner.Movements
{
    public class PlayerJumpManager : IJumpService
    {
        readonly IPlayerController _playerController;
        readonly IJumpDal _jumpDal;
         
        bool _canJump;
        int _currentJumpCounter = 0;
        int _maxJumpCounter = 1;
        
        public PlayerJumpManager(IPlayerController playerController, IJumpDal jumpDal)
        {
            _playerController = playerController;
            _jumpDal = jumpDal;
        }
        
        public void Tick()
        {
            if (_playerController.InputReader.Jump && _currentJumpCounter < _maxJumpCounter)
            {
                _currentJumpCounter++;
                _canJump = true;
            }
        }

        public void FixedTick()
        {
            if (_canJump)
            {
                _jumpDal.JumpProcess();
            }

            _canJump = false;
        }

        public void ResetCounter()
        {
            _currentJumpCounter = 0;
        }
    }
}