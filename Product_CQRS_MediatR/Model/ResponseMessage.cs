using System.Net;

namespace Product_CQRS_MediatR.Model
{
    public class ResponseMessage
    {

        public ResponseMessage()
        {
            Message = "عملیات با موفقیت انجام شد";
        }

        public ResponseMessage(object content)
        {
            Message = "عملیات با موفقیت انجام شد";
            Content = content;
        }

        public ResponseMessage(string message)
        {
            Message = message;
        }

        public ResponseMessage(string message, object content)
        {
            Message = message;
            Content = content;
        }
        public ResponseMessage(HttpStatusCode status)
        {
            Status = status;
        }
        public string Message { get; private set; }
        public object Content { get; private set; }
        public HttpStatusCode Status { get; private set; } = HttpStatusCode.OK;
    }
}

