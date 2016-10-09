
namespace RnD.Net.Serializing.Management
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    [Serializable]
    internal class FullControlSerializingObject
    {
        public double high;
        public double width;

        public FullControlSerializingObject(double high, double width)
        {
            this.high = high;
            this.width = width;
        }

        [OnSerializing]
        void DoBeforeSerializing(StreamingContext context)
        {
            this.high *= 10;
            this.width *= 10;
        }

        [OnSerialized]
        void DoAfterSerializing(StreamingContext context)
        {
        }

        [OnDeserializing]
        void DoBeforeDeserialing(StreamingContext context)
        {
        }

        [OnDeserialized]
        void DoAfterDeserialing(StreamingContext context)
        {
            this.high *= 10;
            this.width *= 10;
        }
    }
}
