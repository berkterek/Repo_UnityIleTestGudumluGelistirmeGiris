using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityTddBeginner.EditTests.Helpers;
using UnityTddBeginner.Movements;

namespace Movements
{
    public class player_jump
    {
        [Test]
        public void player_jump_one_time_if_can_jump_is_true()
        {
            var player = EditModeHelper.GetPlayerController();
            player.Stats.JumpForce.Returns(1000f);
            player.transform.gameObject.AddComponent<Rigidbody2D>();
            var playerJump = new PlayerForceJump(player);

            float startForce = playerJump.JumpForce;

            for (int i = 0; i < 50; i++)
            {
                player.InputReader.Jump.Returns(true);
                playerJump.Tick();
                playerJump.FixedTick();
            }
            
            Assert.Greater(playerJump.JumpForce, startForce);
        }
        
        [Test]
        public void player_can_not_jump_one_time_if_can_jump_is_false()
        {
            var player = EditModeHelper.GetPlayerController();
            player.Stats.JumpForce.Returns(1000f);
            player.transform.gameObject.AddComponent<Rigidbody2D>();
            var playerJump = new PlayerForceJump(player);

            float startForce = playerJump.JumpForce;

            for (int i = 0; i < 50; i++)
            {
                player.InputReader.Jump.Returns(false);
                playerJump.Tick();
                playerJump.FixedTick();
            }
            
            Assert.AreEqual(startForce,playerJump.JumpForce);
        }
    }    
}

