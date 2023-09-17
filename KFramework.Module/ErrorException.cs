using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace KFramework.Module
{
    [Serializable]
    public class ErrorException : Exception
    {
        public ErrorException(
            string key,
            string messageTemplate,
            Dictionary<string, object> arguments = null,
            string debugMessage = null,
            string field = null,
            Exception innerException = null)
            : base(GetMessage(messageTemplate, arguments), innerException)
        {
            Key = key;
            MessageTemplate = messageTemplate;
            Arguments = arguments;
            Field = field;
            DebugMessage = debugMessage;
        }

        protected ErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string Field { get; }

        public string Key { get; }

        public string MessageTemplate { get; }

        public Dictionary<string, object> Arguments { get; }

        public string DebugMessage { get; }

        static string GetMessage(string message, Dictionary<string, object> arguments)
        {
            if (arguments != null)
            {
                StringBuilder builder = new StringBuilder(message);
                foreach (var argument in arguments)
                {
                    builder.Replace($"{{{argument.Key}}}", Convert.ToString(argument.Value));
                }

                message = builder.ToString();
            }

            return message;
        }
    }
}
