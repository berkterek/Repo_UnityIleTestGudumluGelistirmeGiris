using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityTddBeginner.Controllers;

namespace Combats
{
    public class player_health
    {
        [UnityTest]
        public IEnumerator player_take_one_damage()
        {
            yield return SceneManager.LoadSceneAsync("CombatTest");
            
            var player = GameObject.FindObjectOfType<PlayerController>();
            var enemy = GameObject.FindObjectOfType<EnemyController>();

            int maxHealth = player.Health.CurrentHealth;
            Vector3 playerPosition = player.transform.position;
            enemy.transform.position = playerPosition;
            
            yield return new WaitForSeconds(1f);
            
            Assert.AreEqual(maxHealth - 1, player.Health.CurrentHealth);
        }
    }    
}

