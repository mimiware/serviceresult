using System.Collections.Generic;
using Xunit;

namespace Mimiware.ServiceResult.Tests
{
    public class ServiceResultTests
    {
        [Fact]
        public void OkResult_CreatedByConstructor()
        {
            // Arrange
            var result = new ServiceResult();

            // Act
            var returnValue = result.Ok();

            // Assert
            Assert.Equal(ServiceResultCode.Ok, returnValue.Code);
            Assert.True(result.IsSuccessCode);
        }

        [Fact]
        public void OkResult_NotCreatedByConstructor()
        {
            // Arrange
            var result = new ServiceResult {Code = ServiceResultCode.Ok};

            // Assert
            Assert.Equal(ServiceResultCode.Ok, result.Code);
            Assert.True(result.IsSuccessCode);
        }

        [Fact]
        public void OkNoContentResult()
        {
            // Arrange
            var result = new ServiceResult();

            // Act
            var returnValue = result.Ok(ServiceResultCode.OkNoContent);

            // Assert
            Assert.Equal(ServiceResultCode.OkNoContent, returnValue.Code);
            Assert.True(result.IsSuccessCode);
        }

        [Fact]
        public void OkCreatedResult()
        {
            // Arrange
            var result = new ServiceResult();

            // Act
            var returnValue = result.Ok(ServiceResultCode.OkCreated);

            // Assert
            Assert.Equal(ServiceResultCode.OkCreated, returnValue.Code);
            Assert.True(result.IsSuccessCode);
        }

        [Theory]
        [MemberData(nameof(ServiceResultCodeTestData))]
        public void ServiceResultCodeTests(int code, bool isSuccessCode)
        {
            // Arrange
            var result = new ServiceResult();

            // Act
            var returnValue = result.Ok(code);

            // Assert
            Assert.Equal(code, returnValue.Code);
            Assert.Equal(isSuccessCode, result.IsSuccessCode);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> ServiceResultCodeTestData()
        {
            yield return new object[] {ServiceResultCode.OkCreated, true};
            yield return new object[] {ServiceResultCode.Ok, true}; 
            yield return new object[] {ServiceResultCode.OkNoContent, true};
            yield return new object[] {ServiceResultCode.BadRequest, false};
            yield return new object[] {ServiceResultCode.Conflict, false};
            yield return new object[] {ServiceResultCode.Forbidden, false };
            yield return new object[] { ServiceResultCode.Gone, false };
            yield return new object[] { ServiceResultCode.InternalError, false };
            yield return new object[] { ServiceResultCode.NotFound, false };
            yield return new object[] { ServiceResultCode.ServiceUnavailable, false };
            yield return new object[] { ServiceResultCode.UnAuthorized, false };


        }
    }
}
