using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Movements;

namespace UnityTddBeginner.Movements
{
    public class PlayerMoveWithTranslate : IMover
    {
        readonly IPlayerController _playerController;
        readonly Transform _transform;
        
        float _moveSpeed = 1f;
        float _horizontalInput = 0f;
        
        public PlayerMoveWithTranslate(IPlayerController playerController)
        {
            _playerController = playerController;
            _transform = playerController.transform;
        }
        
        public void Tick()
        {
            _horizontalInput = _playerController.InputReader.Horizontal;
        }

        public void FixedTick()
        {
            _transform.Translate(Vector2.right * _horizontalInput * (_moveSpeed *Time.deltaTime));
        }
    }    
}