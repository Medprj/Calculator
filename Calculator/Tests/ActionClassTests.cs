using BusinessLogic;
using Domain;
using Xunit;
using Moq;

namespace Tests
{
    public class ActionClassTests
    {
        private readonly Mock<IOperation> operation;
        private readonly Mock<ITypeElement> typeElem;
        private readonly Mock<IAction> action;
        private readonly CalculateRpn calcRpn;

        public ActionClassTests()
        {
            operation = new Mock<IOperation>();
            typeElem = new Mock<ITypeElement>();
            action = new Mock<IAction>();
            calcRpn = new CalculateRpn(action.Object, operation.Object, typeElem.Object);
        }


        [Fact]
        public void ExecuteMathematicalOperation()
        {
            var operationName = "Addition";
            var parametrs = new[] { 2.2, 3.3 }; 
            var testResult = "5.5";
            var fileNameAssembly = "base.dll";
            var fullNameType = "base.Operations";

            action.Setup(m => m.Exec(operationName, parametrs, fileNameAssembly, fullNameType)).Returns(testResult);

            var result = calcRpn.ExecMathOperation(operationName, parametrs, fileNameAssembly, fullNameType);

            Assert.Equal("5.5", result);
        }

    }
}