using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [InlineData("0,0,0", 0)]
        [InlineData("0,1,2", 3)]
        [InlineData("1,2,3", 6)]
        public void Add_MultipleNumbers_ReturnsSumOfNumbers(string input, int expected)
        {
            //var stringCalculator = new StringCalculator();

            //var actual = stringCalculator.Add(input);

            //Assert.Equal(expected, actual);
            System.Console.WriteLine("in:" + input);

        }
    }
}
