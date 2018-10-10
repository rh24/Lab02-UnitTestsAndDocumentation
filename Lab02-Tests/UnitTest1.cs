using Xunit;
using static Lab02_UnitTestsAndDocumentation.Program;

namespace Lab02_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(5000, Balance());
        }
    }
}
