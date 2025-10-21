using Xunit;

namespace Mimiware.ServiceResult.Tests
{
    public class ServiceResultErrorTests
    {
        [Fact]
        public void ServiceResultError_WithMessage()
        {
            const string ExpectedMessage = "Failed";
            IServiceResultError error = new ServiceResultError(ExpectedMessage);

            Assert.Equal(ExpectedMessage, error.ErrorMessage);
        }

        [Fact]
        public void ServiceResultError_ShouldReturnErrorMessageWhenInterpolated()
        {
            IServiceResultError error = new ServiceResultError("A very specific error occurred.");

            Assert.Equal(error.ErrorMessage, $"{error}");
        }
    }
}
