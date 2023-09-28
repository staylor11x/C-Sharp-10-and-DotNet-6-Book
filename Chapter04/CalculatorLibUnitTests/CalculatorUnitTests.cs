using Packt;

namespace CalculatorLibUnitTests
{
    public class CalculatorUnitTests
    {
        [Fact]
        public void TestAdding2And2()
        {
            // arrange
            double a = 2;
            double b = 2;
            double expected = 4;
            Calculator calc = new();

            // act 
            double actual = calc.Add(a, b);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAdding3And2()
        {
            //arrange
            double a = 3;
            double b = 2;
            double expected = 5;
            Calculator calc = new();

            // act 
            double actual = calc.Add(a, b);

            // assert 
            Assert.Equal(expected, actual);
        }
    }
}