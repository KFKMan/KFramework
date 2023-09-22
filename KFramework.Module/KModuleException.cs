using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace KFramework.Module
{
    [Serializable]
    public class KModuleException : Exception
    {
        public KModuleException(
            string key,
            string messageTemplate,
            Dictionary<string, object>? arguments = null,
            string? debugMessage = null,
            string? field = null,
            Exception? innerException = null)
            : base(GetMessage(messageTemplate, arguments), innerException)
        {
            Key = key;
            MessageTemplate = messageTemplate;
            if (arguments != null)
            {
                Arguments = arguments;
            }
            if (field != null)
            {
                Field = field;
            }
            if (debugMessage != null)
            {
                DebugMessage = debugMessage;
            }
        }

        protected KModuleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string Field { get; } = string.Empty;

        public string Key { get; } = string.Empty;

        public string MessageTemplate { get; } = string.Empty;

        public Dictionary<string, object> Arguments { get; } = new();

        public string DebugMessage { get; } = string.Empty;

        static string GetMessage(string message, Dictionary<string, object>? arguments)
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
