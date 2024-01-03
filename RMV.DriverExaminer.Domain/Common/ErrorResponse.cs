namespace RMV.DriverExaminer.Domain.Common
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }

        public ErrorResponse(int statusCode, string message, string details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
    }
}
