using UnityEngine;
using UnityTddBeginner.Abstracts.Movements;

namespace UnityTddBeginner.Movements
{
    public class ForceJumpDal : IJumpDal
    {
        readonly Rigidbody2D _rigidbody2D;

        public ForceJumpDal(Rigidbody2D rigidbody)
        {
            _rigidbody2D = rigidbody;
        }
        
        public void JumpProcess(float value)
        {
            float jumpForceValue = value * Time.deltaTime;
            _rigidbody2D.AddForce(jumpForceValue * Vector3.up);
        }
    }
    
    public class VelocityJumpDal : IJumpDal
    {
        readonly Rigidbody2D _rigidbody2D;

        public VelocityJumpDal(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }
        
        public void JumpProcess(float value)
        {
            float jumpForceValue = value * Time.deltaTime;
            _rigidbody2D.velocity = jumpForceValue * Vector3.up;
        }
    }

    public class TransformPositionJumpDal : IJumpDal
    {
        readonly Transform _transform;

        public TransformPositionJumpDal(Transform transform)
        {
            _transform = transform;
        }
        
        public void JumpProcess(float value)
        {
            float jumpForceValue = value * Time.deltaTime;
            _transform.position += jumpForceValue * Vector3.up;
        }
    }
}