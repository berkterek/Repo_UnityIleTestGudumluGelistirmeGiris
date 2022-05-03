using System.Collections;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace SampleTests
{
    public class first_play_mode_test
    {
        [UnityTest]
        public IEnumerator number1_and_number2_value_plus_result_equal_30()
        {
            //Arrange
            int number1 = 10;
            int number2 = 20;
            int expectedResult = 30;

            //Act
            int result = number1 + number2;

            //Assert
            Assert.AreEqual(expectedResult, result);
            yield return null;
        }

        [UnityTest]
        public IEnumerator number1_and_number2_and_number3_value_plus_result_equal_30()
        {
            //Arrange
            int number1 = 10;
            int number2 = 15;
            int number3 = 5;
            int expectedResult = 30;

            //Act
            int result = number1 + number2 + number3;

            //Assert
            Assert.AreEqual(expectedResult, result);
            yield return null;
        }

        [UnityTest]
        [CanBeNull]
        public IEnumerator create_new_game_object_and_find_on_scene()
        {
            //Arrange
            string name = "NewObject";
            GameObject gameObject = new GameObject(name);

            //Act
            yield return new WaitForSeconds(1f);
            GameObject findObject = GameObject.Find(name);
            yield return new WaitForSeconds(1f);

            //Assert
            Assert.AreSame(gameObject,findObject);
        }
    }
}