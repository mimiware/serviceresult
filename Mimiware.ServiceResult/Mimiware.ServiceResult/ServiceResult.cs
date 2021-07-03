namespace Mimiware.ServiceResult
{
    /// <summary>
    /// Typed service result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IServiceResult<T> : IServiceResult
    {
        /// <summary>
        /// Result data/content
        /// </summary>
        T Data { get; set; }

        /// <summary>
        /// Creates a successful result, with content of type T
        /// </summary>
        /// <param name="content"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        IServiceResult<T> Ok(T content, int code = ServiceResultCode.Ok);

        /// <summary>
        /// Creates an error result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        IServiceResult<T> Error(
            int code = ServiceResultCode.InternalError,
            string message = null);
    }

    /// <inheritdoc cref="IServiceResult{T}"/>
    public class ServiceResult<T> : ServiceResult, IServiceResult<T>
    {
        public T Data { get; set; }

        public IServiceResult<T> Ok(T content, int code = ServiceResultCode.Ok)
        {
            Data = content;
            Code = code;

            return this;
        }

        public IServiceResult<T> Error(
            int code = ServiceResultCode.InternalError,
            string message = null)
        {
            return new ServiceResult<T>
            {
                Code = code,
                ErrorMessage = new ServiceResultError(message)
            };
        }
    }

    /// <summary>
    /// Service result without data/content
    /// </summary>
    public interface IServiceResult
    {
        /// <summary>
        /// Service result code
        /// </summary>
        int Code { get; set; }

        /// <summary>
        /// Checks if the operation was successful or not
        /// </summary>
        /// <returns>Returns TRUE if Code is <see cref="ServiceResultCode.Ok"/>, <see cref="ServiceResultCode.OkCreated"/>
        /// or <see cref="ServiceResultCode.OkNoContent"/>, otherwise false
        /// </returns>
        bool IsSuccessCode { get; }

        /// <summary>
        /// Error message content
        /// </summary>
        /// <inheritdoc cref="IServiceResult"/>
        IServiceResultError ErrorMessage { get; set; }

        /// <summary>
        /// Creates a successful result
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IServiceResult Ok(int code = ServiceResultCode.Ok);
    }

    /// <inheritdoc cref="IServiceResult"/>
    public class ServiceResult : IServiceResult
    {
        public int Code { get; set; }

        public IServiceResultError ErrorMessage { get; set; }

        public bool IsSuccessCode => 
            Code == ServiceResultCode.Ok || 
            Code == ServiceResultCode.OkCreated || 
            Code == ServiceResultCode.OkNoContent;

        public IServiceResult Ok(int code = ServiceResultCode.Ok)
        {
            Code = code;
            return this;
        }

        public IServiceResult Error(string message, int code = ServiceResultCode.InternalError)
        {
            Code = code;
            ErrorMessage = new ServiceResultError(message);
            return this;
        }
    }

}
