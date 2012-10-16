using Domain;
using Xunit;

namespace Tests
{
    public class OperationClassTests
    {
        private readonly Operation<Operations> operation;
        public OperationClassTests()
        {
            operation = new Operation<Operations>();
        }
        
        [Fact]
        public void GetCountOperandsForOperation()
        {
            var result = operation.GetCountOperands("+");
            Assert.Equal(2, result);
        }

        [Fact]
        public void GetCountOperandsForFunctionWithOneParametrs()
        {
            var result = operation.GetCountOperands("Sin");
            Assert.Equal(1, result);
        }

        [Fact]
        public void GetCountOperandsIfMissingNameOperation()
        {
            var result = operation.GetCountOperands("");
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetCountOperandIfTakeNull()
        {
            var result = operation.GetCountOperands(null);
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetCountOperandIfTakeIncorrectData()
        {
            var result = operation.GetCountOperands("Sin20");
            Assert.Equal(0, result);
        }
    }
}