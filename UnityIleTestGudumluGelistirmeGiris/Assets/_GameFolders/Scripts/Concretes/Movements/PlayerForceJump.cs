using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Movements;

namespace UnityTddBeginner.Movements
{
    public class PlayerForceJumpDal : IJumpDal
    {
        readonly IPlayerController _playerController;
        readonly Rigidbody2D _rigidbody2D;

        public PlayerForceJumpDal(IPlayerController playerController)
        {
            _playerController = playerController;
            _rigidbody2D = _playerController.transform.GetComponent<Rigidbody2D>();
        }
        
        public void JumpProcess()
        {
            float jumpForceValue = _playerController.Stats.JumpForce * Time.deltaTime;
            _rigidbody2D.AddForce(Vector3.up * jumpForceValue);
        }
    }
}