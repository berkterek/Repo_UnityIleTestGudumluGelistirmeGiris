using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Movements;

namespace Movements
{
    public class player_flip : MonoBehaviour
    {
        private IPlayerController GetPlayer(float horizontalInput)
        {
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject parent = new GameObject();
            GameObject body = new GameObject();
            body.transform.SetParent(parent.transform);
            playerController.transform.Returns(parent.transform);
            playerController.InputReader.Returns(Substitute.For<IInputReader>());
            playerController.InputReader.Horizontal.Returns(horizontalInput);

            return playerController;
        }
        
        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void player_get_input_value_body_scale_x_result_equal_input_value(float horizontalInput)
        {
            //Arrange
            var playerController = GetPlayer(horizontalInput);
            
            IFlip flip = new PlayerFlipWithScale(playerController);
            
            //Act
            for (int i = 0; i < 10; i++)
            {
                flip.Tick();    
            }
            
            //Assert
            Assert.AreEqual(horizontalInput, playerController.transform.GetChild(0).transform.localScale.x);
        }
        
        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void player_get_input_value_after_input_get_0_body_scale_x_result_equal_first_input_value(float horizontalInput)
        {
            //Arrange
            var playerController = GetPlayer(horizontalInput);
            
            IFlip flip = new PlayerFlipWithScale(playerController);
            float firstInputValue = horizontalInput; 
            
            //Act
            for (int i = 0; i < 10; i++)
            {
                flip.Tick();    
            }

            horizontalInput = 0;
            playerController.InputReader.Horizontal.Returns(horizontalInput);

            for (int i = 0; i < 3; i++)
            {
                flip.Tick();
            }
            
            //Assert
            Assert.AreEqual(firstInputValue, playerController.transform.GetChild(0).transform.localScale.x);
        }
    }    
}