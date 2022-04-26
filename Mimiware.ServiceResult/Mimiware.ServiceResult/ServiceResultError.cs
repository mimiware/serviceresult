using System;
using System.Collections.Generic;
using System.Text;

namespace Mimiware.ServiceResult
{
    /// <summary>
    /// Service result error
    /// </summary>
    public interface IServiceResultError
    {
        /// <summary>
        /// Error message
        /// </summary>
        string ErrorMessage { get; set; }
    }


    /// <inheritdoc cref="IServiceResultError"/>
    public class ServiceResultError : IServiceResultError
    {
        /// <inheritdoc cref="IServiceResultError.ErrorMessage"/>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Create an instance if <see cref="ServiceResultError"/> with a message
        /// </summary>
        /// <param name="message">Error message</param>
        public ServiceResultError(string message)
        {
            ErrorMessage = message;
        }

        /// <summary>
        /// Error message
        /// </summary>
        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}
