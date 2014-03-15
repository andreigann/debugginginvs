using System;
using System.Runtime.Serialization;

namespace IasiDevDemo.Infrastructure
{
    public class DemoException : Exception
    {
        public DemoException()
        {
        }

        public DemoException(string message) : base(message)
        {
        }

        public DemoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DemoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}