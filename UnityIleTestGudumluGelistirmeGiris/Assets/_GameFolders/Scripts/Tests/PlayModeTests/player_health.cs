using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.ScriptableObjects;
using UnityTddBeginner.Combats;
using UnityTddBeginner.Controllers;

namespace Combats
{
    public class player_health
    {
        IEnemyController _enemy;
        IPlayerController _player;
        IStats _enemyStats;

        [UnitySetUp]
        public IEnumerator SetupAsync()
        {
            yield return SceneManager.LoadSceneAsync("CombatTest");

            _player = GameObject.FindObjectOfType<PlayerController>();
            _enemy = GameObject.FindObjectOfType<EnemyController>();
            _enemyStats = Substitute.For<IStats>();
        }

        [UnityTest]
        [TestCase(1,ExpectedResult = (IEnumerator)null)]
        [TestCase(2, ExpectedResult = (IEnumerator)null)]
        [TestCase(5, ExpectedResult = (IEnumerator)null)]
        [TestCase(10, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_take_one_damage_in_one_time(int damageValue)
        {
            _enemyStats.CalculateDamage.Returns(damageValue);
            _enemy.Attacker = new Attacker(_enemyStats);
            int maxHealth = _player.Health.CurrentHealth;
            Vector3 playerPosition = _player.transform.position;
            _enemy.transform.position = playerPosition;

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(maxHealth - damageValue, _player.Health.CurrentHealth);
        }

        [UnityTest]
        [TestCase(0f,1f,ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f,0f,ExpectedResult = (IEnumerator)null)]
        [TestCase(1f,0f,ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_take_one_damage_from_up_left_right_side(float x, float y)
        {
            Vector3 attackPosition = new Vector3(x, y, 0f);
            int damageValue = 1;
            _enemyStats.CalculateDamage.Returns(damageValue);
            int maxHealth = _player.Health.CurrentHealth;
            Vector3 playerNearestPosition = _player.transform.position + (attackPosition / 2f);
            _enemy.transform.position = playerNearestPosition;
            
            yield return new WaitForSeconds(1f);
            
            Assert.AreEqual(maxHealth - damageValue, _player.Health.CurrentHealth);
        }

        [UnityTest]
        public IEnumerator player_take_none_damage_from_down_side()
        {
            _enemyStats.CalculateDamage.Returns(1);
            int maxHealth = _player.Health.CurrentHealth;
            Vector3 playerNearestPosition = _player.transform.position + (Vector3.down / 2f);
            _enemy.transform.position = playerNearestPosition;
            
            yield return new WaitForSeconds(1f);
            
            Assert.AreEqual(maxHealth, _player.Health.CurrentHealth);
        }
    }
}