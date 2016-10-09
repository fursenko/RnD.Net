
namespace RnD.Net.Serializing.Surrogate
{
    using System;
    using System.Runtime.Serialization;

    internal sealed class DateTimeSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Date", ((DateTime)obj).ToUniversalTime().ToString("u"));
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            return DateTime.ParseExact(info.GetString("Date"), "u", null).ToLocalTime();
        }
    }
}
