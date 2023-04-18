namespace Mimiware.ServiceResult
{
    /// <summary>
    /// Pre-defined service result codes
    /// </summary>
    public static class ServiceResultCode
    {
        public const int Ok = 200;
        public const int OkCreated = 201;
        public const int OkNoContent = 204;
        public const int BadRequest = 400;
        public const int UnAuthorized = 401;
        public const int PaymentRequired = 402;
        public const int Forbidden = 403;
        public const int NotFound = 404;
        public const int MethodNotAllowed = 405;
        public const int Conflict = 409;
        public const int Gone = 410;
        public const int InternalError = 500;
        public const int BadGateway = 502;
        public const int ServiceUnavailable = 503;
    }
}
