using NUnit.Framework;

namespace SampleTests
{
    public class first_edit_test_script
    { 
        [Test]
        public void number1_and_number2_value_plus_result_equal_30()
        {
            //Arrange
            int number1 = 10;
            int number2 = 20;
            int expectedResult = 30;

            //Act
            int result = number1 + number2;

            //Assert
            Assert.AreEqual(expectedResult,result);
        }
    
        [Test]
        public void number1_and_number2_and_number3_value_plus_result_equal_30()
        {
            //Arrange
            int number1 = 10;
            int number2 = 15;
            int number3 = 5;
            int expectedResult = 30;

            //Act
            int result = number1 + number2 + number3;

            //Assert
            Assert.AreEqual(expectedResult,result);
        }
    }    
}