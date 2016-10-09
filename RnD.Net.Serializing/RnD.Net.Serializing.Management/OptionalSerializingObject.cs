
namespace RnD.Net.Serializing.Management
{
    using System.Runtime.Serialization;
    using System;

    [Serializable]
    internal class OptionalSerializingObject
    {
        [OptionalField]
        internal double x;

        [OptionalField]
        internal double y;

        [OptionalField]
        internal double z;

        [OptionalField]
        internal double a1;
    }
}
