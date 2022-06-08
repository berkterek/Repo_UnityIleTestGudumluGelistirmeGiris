using NUnit.Framework;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Movements;
using NSubstitute;
using UnityEngine;
using UnityTddBeginner.EditTests.Helpers;

namespace Movements
{
    public class player_movement
    {
        private IPlayerController GetPlayer()
        {
            var playerController = EditModeHelper.GetPlayerController();
            playerController.Stats.MoveSpeed.Returns(5f);

            return playerController;
        }

        private IMover GetMover(IPlayerController playerController)
        {
            IMover mover = new PlayerMoveWithTranslate(playerController);
            return mover;
        }
        
        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void move_10_meters_right_or_left_not_equal_start_position(float horizontalInputValue)
        {
            //Arrange
            var playerController = GetPlayer();
            var mover = GetMover(playerController);
            Vector3 startPosition = playerController.transform.position;

            //Act
            playerController.InputReader.Horizontal.Returns(horizontalInputValue);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick(); //input
                mover.FixedTick(); //input ile aksiyon
            }

            //Assert
            Assert.AreNotEqual(startPosition,playerController.transform.position);
        }
        
        [Test]
        public void move_10_meters_right_end_position_greater_than_start_position()
        {
            //Arrange
            var playerController = GetPlayer();
            var mover = GetMover(playerController);
            Vector3 startPosition = playerController.transform.position;

            //Act
            playerController.InputReader.Horizontal.Returns(1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick(); //input
                mover.FixedTick(); //input ile aksiyon
            }

            //Assert
            Assert.Greater(playerController.transform.position.x,startPosition.x);
        }
        
        [Test]
        public void move_10_meters_left_end_position_greater_than_start_position()
        {
            //Arrange
            var playerController = GetPlayer();
            var mover = GetMover(playerController);
            Vector3 startPosition = playerController.transform.position;

            //Act
            playerController.InputReader.Horizontal.Returns(-1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick(); //input
                mover.FixedTick(); //input ile aksiyon
            }
            
            //Assert
            Assert.Less(playerController.transform.position.x,startPosition.x);
        }
    }    
}

