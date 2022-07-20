using System;
using System.Collections.Generic;

namespace Cart.Application.Core
{
    public class MessageError
    {
        public MessageError()
        {
            Subs = new List<SubMessageError>();
        }

        public MessageError(string code, Exception exception)
            : this()
        {
            Code = code;
            Message = exception.Message;

            if (exception.InnerException != null)
                Subs.Add(new SubMessageError(exception.InnerException));
        }

        public MessageError(string code, string message, string subMessage)
            : this()
        {
            Code = code;
            Message = message;
            SubMessage = subMessage;
        }
        public string Code { get; set; }
        public string Message { get; set; }
        public string SubMessage { get; set; }
        public IList<SubMessageError> Subs { get; set; }

        public override string ToString() => System.Text.Json.JsonSerializer.Serialize(this);
    }

    public class SubMessageError
    {
        public SubMessageError() { }
        public SubMessageError(Exception exception)
        {
            Message = exception.Message;
        }
        public SubMessageError(string subMessage)
        {
            Message = subMessage;
        }
        public string Id { get; set; }
        public string Message { get; set; }
    }
}
