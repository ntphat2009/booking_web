using System.Net;

namespace Booking.API
{
    public class BaseApiResponse
    {
        public BaseApiResponse()
        {
            ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
        public string Message { get; set; }

        public BaseApiResponse Success(object result)
        {
            StatusCode = HttpStatusCode.OK;
            IsSuccess = true;
            Result = result;
            return this;
        }
        public BaseApiResponse Failed(HttpStatusCode statusCode, List<string> errorMessages, object result)
        {
            StatusCode = statusCode;
            IsSuccess = false;
            Result = result;
            ErrorMessages = errorMessages;
            return this;
        }
    }
}
