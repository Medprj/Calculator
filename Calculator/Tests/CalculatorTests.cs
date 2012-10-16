using BusinessLogic;
using Xunit;
using Moq;

namespace Tests
{
    public class CalculatorTests
    {
        private readonly Mock<IConvertToArray> convertToArray;
        private readonly Mock<IConvertToRpn> convertToRpn;
        private readonly Mock<ICalculateRpn> calcRpn;
        private readonly Calculator calculator;

        public CalculatorTests()
        {
            convertToArray = new Mock<IConvertToArray>();
            convertToRpn = new Mock<IConvertToRpn>();
            calcRpn = new Mock<ICalculateRpn>();
            calculator = new Calculator(convertToArray.Object, convertToRpn.Object, calcRpn.Object);
        }

        [Fact]
        public void ConvertMathExpressFromStringToArray()
        {
            convertToArray.Setup(m => m.ToArray("1+3")).Returns(new[] {"1", "+", "3"});
            
            var result = calculator.ConvertToArray("1+3");

            Assert.Equal(new[]{"1","+","3"}, result);
        }

        [Fact]
        public void ConvertMathExpressFromInfixToPostfixNotation()
        {
            convertToRpn.Setup(m => m.ToRpn(new[] {"2", "*", "4"})).Returns(new[] {"2", "4", "*"});

            var result = calculator.ConvertToRpn(new[] {"2", "*", "4"});

            Assert.Equal(new[]{"2","4","*"}, result);
        }

        [Fact]
        public void CalculatePostfixNotation()
        {
            calcRpn.Setup(m => m.Calculate(new[] {"5", "2", "-"})).Returns("3");

            var result = calculator.CalculateRpn(new[]{"5","2","-"});

            Assert.Equal("3", result);
        }

        [Fact]
        public void Calculate()
        {
            convertToArray.Setup(m => m.ToArray("2-1")).Returns(new[] { "2", "-", "1" });

            convertToRpn.Setup(m => m.ToRpn(new[] { "2", "-", "1" })).Returns(new[] { "2", "1", "-" });

            calcRpn.Setup(m => m.Calculate(new[] { "2", "1", "-" })).Returns("1");

            var result = calculator.Calc("2-1");
            Assert.Equal("1", result);
        }
    }
}
