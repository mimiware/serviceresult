namespace Mimiware.ServiceResult
{
    /// <summary>
    /// Typed service result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IServiceResult<T>
    {
        /// <summary>
        /// Result data/content
        /// </summary>
        T Data { get; set; }

        /// <summary>
        /// Checks if the operation was successful or not
        /// </summary>
        bool IsSuccessCode { get; }

        /// <summary>
        /// Service result code
        /// </summary>
        int Code { get; set; }

        /// <summary>
        /// Error message content
        /// </summary>
        IServiceResultError ErrorMessage { get; set; }

        /// <summary>
        /// Creates a successful result
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
    public class ServiceResult<T> : ServiceResultBase, IServiceResult<T>
    {
        public T Data { get; set; }

        public bool IsSuccessCode => Code == ServiceResultCode.Ok;

        public IServiceResult<T> Ok(T content, int code = ServiceResultCode.Ok)
        {
            return new ServiceResult<T>
            {
                Code = code,
                Data = content
            };
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
    public interface IServiceResultBase
    {
        /// <summary>
        /// Service result code
        /// </summary>
        int Code { get; set; }

        /// <summary>
        /// Error message content
        /// </summary>
        IServiceResultError ErrorMessage { get; set; }

        /// <summary>
        /// Creates a successful result
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IServiceResultBase Ok(int code = ServiceResultCode.Ok);
    }

    /// <inheritdoc cref="IServiceResultBase"/>
    public class ServiceResultBase : IServiceResultBase
    {
        public int Code { get; set; }
        public IServiceResultError ErrorMessage { get; set; }

        public IServiceResultBase Ok(int code = ServiceResultCode.Ok)
        {
            return new ServiceResultBase
            {
                Code = code
            };
        }
    }

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
        public string ErrorMessage { get; set; }

        public ServiceResultError(string message)
        {
            ErrorMessage = message;
        }
    }

    /// <summary>
    /// Pre-defined service result codes
    /// </summary>
    public static class ServiceResultCode
    {
        public const int Ok = 200;
        public const int OkCreated = 201;
        public const int UnAuthorized = 401;
        public const int NotFound = 404;
        public const int InternalError = 500;
    }
}
