using PrimeFactorsLib;

namespace PrimeFactorsUnitTests
{
    public class PrimeFactorUnitTests
    {
        [Fact]
        public void Test4()
        {
            //arrange
            int number = 4;
            string expected = "2 x 2";

            //act
            string actual = PrimeFactorsClass.PrimeFactors(number);

            //assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test7()
        {
            //arrange
            int number = 7;
            string expected = "7";

            //act
            string actual = PrimeFactorsClass.PrimeFactors(number);

            //assert
            Assert.Equal(expected , actual);
        }

        [Fact]
        public void Test30()
        {
            //arrange
            int number = 30;
            string expected = "2 x 3 x 5";

            //act 
            string actual = PrimeFactorsClass.PrimeFactors(number);

            //assert
            Assert.Equal(expected , actual);
        }

        [Fact]
        public void Test40()
        {
            //arrange
            int number = 40;
            string expected = "2 x 2 x 2 x 5";

            //act
            string actual = PrimeFactorsClass.PrimeFactors(number);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test50()
        {
            //arrange
            int number = 50;
            string expected = "2 x 5 x 5";

            //act
            string actual = PrimeFactorsClass.PrimeFactors(number);

            //assert
            Assert.Equal(expected, actual);
        }

    }
}