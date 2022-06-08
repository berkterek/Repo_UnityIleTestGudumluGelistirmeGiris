using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Controllers;

namespace Combats
{
    public class player_attack
    {
        IPlayerController _player;
        IEnemyController _enemy;

        [UnitySetUp]
        public IEnumerator SetupAsync()
        {
            yield return SceneManager.LoadSceneAsync("CombatTest");
            _enemy = GameObject.FindObjectOfType<EnemyController>();
            _player = GameObject.FindObjectOfType<PlayerController>();
        }
        
        [UnityTest]
        public IEnumerator player_attack_enemy_one_time()
        {
            //Arrange
            int startHealth = _enemy.Health.CurrentHealth;

            //Act
            Vector3 enemyUpPosition = _enemy.transform.position + Vector3.up / 2f;
            _player.transform.position = enemyUpPosition;

            //Assert

            yield return new WaitForSeconds(1f);

            Assert.AreNotEqual(startHealth, _enemy.Health.CurrentHealth);
        }

        [UnityTest]
        [TestCase(-1f, 0f, ExpectedResult = (IEnumerator)null)]
        [TestCase(1f, 0f, ExpectedResult = (IEnumerator)null)]
        [TestCase(0f, -1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_attack_enemy_left_right_down(float x, float y)
        {
            int startHealth = _enemy.Health.CurrentHealth;

            Vector3 direction = new Vector3(x, y, 0f);
            Vector3 enemyUpPosition = _enemy.transform.position + direction / 2f;
            _player.transform.position = enemyUpPosition;

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(startHealth, _enemy.Health.CurrentHealth);
        }
    }
}