using System.Collections;
using NSubstitute;
using NUnit.Framework;
using PlayModeTest.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Controllers;

namespace Movements
{
    public class player_jump
    {
        [UnityTest]
        public IEnumerator player_jump_one_time()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
            var player = GameObject.FindObjectOfType<PlayerController>();
            player.InputReader = Substitute.For<IInputReader>();

            yield return null;
            float yStartPosition = player.transform.position.y;
            player.InputReader.Jump.Returns(true);
            yield return null;
            player.InputReader.Jump.Returns(false);

            yield return new WaitForSeconds(0.5f);
            Assert.Greater(player.transform.position.y,yStartPosition);
        }

        [UnityTest]
        public IEnumerator player_jump_one_time_but_input_jump_many_time_pressed()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
            var player = GameObject.FindObjectOfType<PlayerController>();
            player.InputReader = Substitute.For<IInputReader>();
            BlockDisableHelper blockDisableHelper = GameObject.FindObjectOfType<BlockDisableHelper>();

            yield return null;
            float yStartPosition = player.transform.position.y;
            player.InputReader.Jump.Returns(true);
            yield return null;
            blockDisableHelper.SetDisableCollider();

            yield return new WaitForSeconds(1.5f);
            Assert.LessOrEqual(player.transform.position.y,yStartPosition);
        }
        
        [UnityTest]
        public IEnumerator player_jump_one_time_wait_after_jump_again()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
            var player = GameObject.FindObjectOfType<PlayerController>();
            player.InputReader = Substitute.For<IInputReader>();

            yield return null;
            float yStartPosition = player.transform.position.y;
            player.InputReader.Jump.Returns(true);
            yield return null;
            player.InputReader.Jump.Returns(false);

            yield return new WaitForSeconds(2f);
            
            player.InputReader.Jump.Returns(true);
            yield return null;
            player.InputReader.Jump.Returns(false);
            
            yield return new WaitForSeconds(0.5f);
            
            Assert.Greater(player.transform.position.y,yStartPosition);
        }
    }    
}

