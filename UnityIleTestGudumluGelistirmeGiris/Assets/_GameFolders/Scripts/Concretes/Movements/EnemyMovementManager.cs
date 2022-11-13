using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Movements;

namespace UnityTddBeginner.Movements
{
    public class EnemyMovementManager : IMovementService
    {
        readonly IEnemyController _enemyController;
        readonly IMoverDal _moverDal;

        float _inputValue = 0f;
        
        public EnemyMovementManager(IEnemyController enemyController, IMoverDal moverDal)
        {
            _enemyController = enemyController;
            _moverDal = moverDal;
        }
        
        public void Tick()
        {
            _inputValue = _enemyController.IsDirectionRight ? 1f : -1;
            _inputValue *= Time.deltaTime * _enemyController.Stats.MoveSpeed;
        }

        public void FixedTick()
        {
            _moverDal.MoveProcess(_inputValue);
        }
    }
}