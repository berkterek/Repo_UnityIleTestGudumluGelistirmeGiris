using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Abstracts.ScriptableObjects;
using UnityTddBeginner.Movements;

namespace Movements
{
    public class enemy_movement
    {
        private IMovementService GetMovementManager(IEnemyController enemyController, IMoverDal moverDal)
        {
            var movementManager = new EnemyMovementManager(enemyController, moverDal);
            return movementManager;
        }

        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void move_10_meters_right_or_left_not_equal_start_position(float horizontalInputValue)
        {
            var enemyController = Substitute.For<IEnemyController>();
            enemyController.Stats.Returns(Substitute.For<IEnemyStats>());
            var moveDal = Substitute.For<IMoverDal>();
            var movementManager = GetMovementManager(enemyController, moveDal);

            enemyController.Stats.MoveSpeed.Returns(5f);
            float inputValue = horizontalInputValue;
            enemyController.IsDirectionRight.Returns(horizontalInputValue == 1f);

            inputValue *= Time.deltaTime * enemyController.Stats.MoveSpeed;

            for (int i = 0; i < 10; i++)
            {
                movementManager.Tick(); //input
                movementManager.FixedTick(); //input ile aksiyon
            }

            moveDal.Received().MoveProcess(inputValue);
        }
    }
}