using Domain;
using Xunit;

namespace Tests
{
    public class TypeElemeClassTests
    {
        private readonly TypeElem typeElem;
        private string result;
        
        public TypeElemeClassTests()
        {
            typeElem = new TypeElem();
        }
        
        [Fact]
        public void GetNumberType()
        {
            result = typeElem.GetType("1");
            Assert.Equal("number".ToLower(), result.ToLower());
        }

        [Fact]
        public void GetFunctionType()
        {
            result = typeElem.GetType("sin");
            Assert.Equal("func".ToLower(), result.ToLower());
        }

        [Fact]
        public void GetSeparatorType()
        {
            result = typeElem.GetType(".");
            Assert.Equal("separator".ToLower(), result.ToLower());
        }

        [Fact]
        public void GetOperationType()
        {
            result = typeElem.GetType("+");
            Assert.Equal("operation".ToLower(), result.ToLower());
        }

        [Fact]
        public void GetOpenParenthesisType()
        {
            result = typeElem.GetType("(");
            Assert.Equal("OpenParenthesis".ToLower(), result.ToLower());
        }

        [Fact]
        public void GetCloseParenthesisType()
        {
            result = typeElem.GetType(")");
            Assert.Equal("CloseParenthesis".ToLower(), result.ToLower());
        }

        [Fact]
        public void TakeEmptyStringGetUnknownType()
        {
            result = typeElem.GetType("");
            Assert.Equal("Unknown".ToLower(), result.ToLower());
        }
    
        [Fact]
        public void TakeNullGetUnknownType()
        {
            result = typeElem.GetType(null);
            Assert.Equal("Unknown".ToLower(), result.ToLower());
        }

        [Fact]
        public void TakeIncorrectDataGetUnknownType()
        {
            result = typeElem.GetType("Simple,123");
            Assert.Equal("Unknown", result);
        }
    }
}