using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Controllers;

namespace Movements
{
    public class enemy_movement
    {
        IEnemyController _enemyController;
        
        private IEnumerator LoadPlayerMoveTestScene()
        {
            yield return SceneManager.LoadSceneAsync("EnemyMovementTest");
        }

        [UnitySetUp]
        IEnumerator Setup()
        {
            yield return LoadPlayerMoveTestScene();
            _enemyController = GameObject.FindObjectOfType<EnemyController>();
        }
        
        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator enemy_move_left_or_right_not_equal_start_position(float inputValue)
        {
            //Arrange
            float startPositionX = _enemyController.transform.position.x;
            
            //Act

            _enemyController.IsDirectionRight = inputValue == 1f;

            yield return new WaitForSeconds(1f);

            Vector3 startPosition = new Vector3(startPositionX, _enemyController.transform.position.y,
                _enemyController.transform.position.z);
            _enemyController.transform.position = startPosition;
            
            yield return new WaitForSeconds(3f);
            //Assert

            if (inputValue < 0f)
            {
                Assert.Less(_enemyController.transform.position.x, startPositionX);    
            }
            else
            {
                Assert.Greater(_enemyController.transform.position.x, startPositionX);
            }
        }
    }
}