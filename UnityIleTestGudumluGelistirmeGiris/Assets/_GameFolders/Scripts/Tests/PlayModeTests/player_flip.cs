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
    public class player_flip
    {
        IPlayerController _playerController;
        
        [UnitySetUp]
        public IEnumerator Setup()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
            
            _playerController = GameObject.FindObjectOfType<PlayerController>();
            _playerController.InputReader = Substitute.For<IInputReader>();
        }
        
        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_get_input_value_body_scale_x_result_equal_input_value(float horizontalInput)
        {
            //Act
            _playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);

            //Assert
            Assert.AreEqual(horizontalInput,_playerController.transform.GetChild(0).transform.localScale.x);
        }
        
        [Test]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_get_input_value_after_input_get_0_body_scale_x_result_equal_first_input_value(float horizontalInput)
        {
            //Arrange
            float firstInputValue = horizontalInput;
            
            //Act
            _playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);

            horizontalInput = 0;
            _playerController.InputReader.Horizontal.Returns(horizontalInput);

            yield return new WaitForSeconds(3f);
            
            //Assert
            Assert.AreEqual(firstInputValue, _playerController.transform.GetChild(0).transform.localScale.x);
        }
    }
}