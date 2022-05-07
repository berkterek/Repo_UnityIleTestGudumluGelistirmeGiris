using NUnit.Framework;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Movements;
using NSubstitute;
using UnityEngine;
using UnityTddBeginner.Abstracts.Inputs;

namespace Movements
{
    public class player_movement
    {
        [Test]
        public void move_10_meters_right_not_equal_start_position()
        {
            //Arrange
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            IMover mover = new PlayerMoveWithTranslate(playerController);
            Vector3 startPosition = playerController.transform.position;

            //Act
            playerController.InputReader.Horizontal.Returns(1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick(); //input
                mover.FixedTick(); //input ile aksiyon
            }

            Debug.Log("Player Start Position => " + startPosition);
            Debug.Log("Player End Position => " + playerController.transform.position);
            
            //Assert
            Assert.AreNotEqual(startPosition,playerController.transform.position);
        }
        
        [Test]
        public void move_10_meters_right_end_position_greater_than_start_position()
        {
            //Arrange
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            IMover mover = new PlayerMoveWithTranslate(playerController);
            Vector3 startPosition = playerController.transform.position;

            //Act
            playerController.InputReader.Horizontal.Returns(1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick(); //input
                mover.FixedTick(); //input ile aksiyon
            }

            Debug.Log("Player Start Position => " + startPosition);
            Debug.Log("Player End Position => " + playerController.transform.position);
            
            //Assert
            Assert.Greater(playerController.transform.position.x,startPosition.x);
        }
        
        [Test]
        public void move_10_meters_left_not_equal_start_position()
        {
            //Arrange
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            IMover mover = new PlayerMoveWithTranslate(playerController);
            Vector3 startPosition = playerController.transform.position;

            //Act
            playerController.InputReader.Horizontal.Returns(-1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick(); //input
                mover.FixedTick(); //input ile aksiyon
            }

            Debug.Log("Player Start Position => " + startPosition);
            Debug.Log("Player End Position => " + playerController.transform.position);
            
            //Assert
            Assert.AreNotEqual(startPosition,playerController.transform.position);
        }
        
        [Test]
        public void move_10_meters_left_end_position_greater_than_start_position()
        {
            //Arrange
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            IMover mover = new PlayerMoveWithTranslate(playerController);
            Vector3 startPosition = playerController.transform.position;

            //Act
            playerController.InputReader.Horizontal.Returns(-1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick(); //input
                mover.FixedTick(); //input ile aksiyon
            }

            Debug.Log("Player Start Position => " + startPosition);
            Debug.Log("Player End Position => " + playerController.transform.position);
            
            //Assert
            Assert.Less(playerController.transform.position.x,startPosition.x);
        }
    }    
}

