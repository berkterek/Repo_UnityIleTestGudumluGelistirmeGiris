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

        private IMovementService GetMovementManager(IPlayerController playerController, IMoverDal moverDal)
        {
            var movementManager = new PlayerMovementManager(playerController, moverDal);
            return movementManager;
        }

        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void move_10_meters_right_or_left_not_equal_start_position(float horizontalInputValue)
        {
            //Arrange
            var playerController = GetPlayer();
            var moveDal = Substitute.For<IMoverDal>();
            var movementManager = GetMovementManager(playerController, moveDal);

            //Act
            playerController.InputReader.Horizontal.Returns(horizontalInputValue);
            playerController.Stats.MoveSpeed.Returns(5f);

            float inputValue = playerController.InputReader.Horizontal * playerController.Stats.MoveSpeed *
                               Time.deltaTime;

            for (int i = 0; i < 10; i++)
            {
                movementManager.Tick(); //input
                movementManager.FixedTick(); //input ile aksiyon
            }

            //Assert
            moveDal.Received().MoveProcess(inputValue);
        }

        [Test]
        public void move_10_meters_right_end_position_greater_than_start_position()
        {
            //Arrange
            var playerController = GetPlayer();
            var moveDal = Substitute.For<IMoverDal>();
            var movementManager = GetMovementManager(playerController, moveDal);

            //Act
            playerController.InputReader.Horizontal.Returns(1f);
            playerController.Stats.MoveSpeed.Returns(5f);

            float inputValue = playerController.InputReader.Horizontal * playerController.Stats.MoveSpeed *
                               Time.deltaTime;
            for (int i = 0; i < 10; i++)
            {
                movementManager.Tick(); //input
                movementManager.FixedTick(); //input ile aksiyon
            }

            //Assert
            moveDal.Received().MoveProcess(inputValue);
        }

        [Test]
        public void move_10_meters_left_end_position_greater_than_start_position()
        {
            //Arrange
            var playerController = GetPlayer();
            var moveDal = Substitute.For<IMoverDal>();
            var movementManager = GetMovementManager(playerController, moveDal);

            //Act
            playerController.InputReader.Horizontal.Returns(-1f);
            playerController.Stats.MoveSpeed.Returns(5f);

            float inputValue = playerController.InputReader.Horizontal * playerController.Stats.MoveSpeed *
                               Time.deltaTime;
            for (int i = 0; i < 10; i++)
            {
                movementManager.Tick(); //input
                movementManager.FixedTick(); //input ile aksiyon
            }

            //Assert
            moveDal.Received().MoveProcess(inputValue);
        }

        [Test]
        public void not_move_when_input_value_equal_zero()
        {
            var playerController = GetPlayer();
            var moveDal = Substitute.For<IMoverDal>();
            var movementManager = GetMovementManager(playerController, moveDal);

            playerController.InputReader.Horizontal.Returns(0f);
            playerController.Stats.MoveSpeed.Returns(5f);

            float inputValue = playerController.InputReader.Horizontal * playerController.Stats.MoveSpeed *
                               Time.deltaTime;

            for (int i = 0; i < 10; i++)
            {
                movementManager.Tick(); //input
                movementManager.FixedTick(); //input ile aksiyon
            }

            moveDal.DidNotReceive().MoveProcess(inputValue);
        }
    }
}