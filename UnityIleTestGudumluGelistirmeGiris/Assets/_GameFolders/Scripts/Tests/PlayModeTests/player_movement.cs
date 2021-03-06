using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Controllers;

namespace Movements
{
    public class player_movement
    {
        IPlayerController _playerController;
        
        private IEnumerator LoadPlayerMoveTestScene()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
        }

        [UnitySetUp]
        IEnumerator Setup()
        {
            yield return LoadPlayerMoveTestScene();
            _playerController = GameObject.FindObjectOfType<PlayerController>();
            _playerController.InputReader = Substitute.For<IInputReader>();
        }
        
        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_move_left_or_right_not_equal_start_position(float inputValue)
        {
            //Arrange
            Vector3 startPosition = _playerController.transform.position;
            
            //Act
            _playerController.InputReader.Horizontal.Returns(inputValue);
            yield return new WaitForSeconds(3f);
            //Assert
            
            Assert.AreNotEqual(startPosition, _playerController.transform.position);
        }

        [UnityTest]
        public IEnumerator player_move_right_end_position_greater_than_start_position()
        {
            Vector3 startPosition = _playerController.transform.position;

            _playerController.InputReader.Horizontal.Returns(1f);
            yield return new WaitForSeconds(3f);
            
            Assert.Greater(_playerController.transform.position.x, startPosition.x);
        }
        
        [UnityTest]
        public IEnumerator player_move_left_end_position_greater_than_start_position()
        {
            Vector3 startPosition = _playerController.transform.position;

            _playerController.InputReader.Horizontal.Returns(-1f);
            yield return new WaitForSeconds(3f);
            
            Assert.Less(_playerController.transform.position.x, startPosition.x);
        }
    }    
}