using CalculatorApp;
using System;
using Xunit;

namespace CalculatorAppTest
{
    public class MathHelperTest
    {
        [Fact]
        public void IsEventTest()
        {
            var calculator = new MathFormulas();

            int x = 1;
            int y = 2;

            var xResult = calculator.IsEven(x);
            var yResult = calculator.IsEven(y);

            Assert.False(xResult);
            Assert.True(yResult);
        }
    }
}
