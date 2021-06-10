using Xunit;

namespace Mimiware.ServiceResult.Tests
{
    public class ServiceResultTests
    {
        [Fact]
        public void Test1()
        {
            var result = new ServiceResult<object>();

            var returnValue = result.Ok();

            Assert.Equal(ServiceResultCode.Ok, returnValue.Code);
        }
    }
}
