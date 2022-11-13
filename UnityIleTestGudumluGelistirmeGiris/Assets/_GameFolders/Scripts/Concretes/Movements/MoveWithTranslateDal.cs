using UnityEngine;
using UnityTddBeginner.Abstracts.Movements;

namespace UnityTddBeginner.Movements
{
    public class MoveWithTranslateDal : IMoverDal
    {
        readonly Transform _transform;

        public MoveWithTranslateDal(Transform transform)
        {
            _transform = transform;
        }

        public void MoveProcess(float value)
        {
            _transform.Translate(value * Vector2.right);
        }
    }

    public class MoveWithRigidbodyDal : IMoverDal
    {
        readonly Rigidbody2D _rigidbody;
        
        public MoveWithRigidbodyDal(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }
        
        public void MoveProcess(float value)
        {
            _rigidbody.MovePosition(value * Vector2.right);
        }
    }
}