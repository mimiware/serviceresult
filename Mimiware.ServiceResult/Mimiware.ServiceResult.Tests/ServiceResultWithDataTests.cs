using Xunit;

namespace Mimiware.ServiceResult.Tests
{
    public class ServiceResultOfTTests
    {
        [Fact]
        public void OkResult_WithContentCreatedByConstructor()
        {
            // Arrange
            var result = new ServiceResult<TestReturnObject>();

            // Act
            var returnValue = result.Ok(new TestReturnObject());

            // Assert
            Assert.Equal(ServiceResultCode.Ok, returnValue.Code);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public void OkResult_WithContentNotCreatedByConstructor()
        {
            // Arrange
            var result = new ServiceResult<TestReturnObject>
            {
                Data = new TestReturnObject()
            };

            // Act
            var returnValue = result.Ok();

            // Assert
            Assert.Equal(ServiceResultCode.Ok, returnValue.Code);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public void OkNoContentResult_WithContent()
        {
            // Arrange
            var result = new ServiceResult<TestReturnObject>();

            // Act
            var returnValue = result.Ok(new TestReturnObject(), ServiceResultCode.OkNoContent);

            // Assert
            Assert.Equal(ServiceResultCode.OkNoContent, returnValue.Code);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public void OkCreatedResult_WithContent()
        {
            // Arrange
            var result = new ServiceResult<TestReturnObject>();

            // Act
            var returnValue = result.Ok(new TestReturnObject(), ServiceResultCode.OkCreated);

            // Assert
            Assert.Equal(ServiceResultCode.OkCreated, returnValue.Code);
            Assert.NotNull(result.Data);
        }
    }

#pragma warning disable S2094 // Classes should not be empty
    public class TestReturnObject { }
#pragma warning restore S2094 // Classes should not be empty
}
