
namespace RnD.Net.Serializing.Singleton
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    internal sealed class SingletonRnD : ISerializable
    {
        static readonly SingletonRnD instance = new SingletonRnD();

        public string name = "robot";
        public DateTime time = DateTime.UtcNow;

        SingletonRnD()
        {
        }

        public static SingletonRnD GetInstance() { return instance; }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(SingletonSerializationHelper));
        }
    }

    [Serializable]
    sealed class SingletonSerializationHelper : IObjectReference
    {
        public object GetRealObject(StreamingContext context)
        {
            return SingletonRnD.GetInstance();
        }
    }
}
