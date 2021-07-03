using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mimiware.ServiceResult.Tests
{
    public class ServiceResultErrorTests
    {
        [Fact]
        public void ServiceResultError_WithMessage()
        {
            const string expectedMessage = "Failed";
            IServiceResultError error = new ServiceResultError(expectedMessage);

            Assert.Equal(expectedMessage, error.ErrorMessage);
        }
    }
}
