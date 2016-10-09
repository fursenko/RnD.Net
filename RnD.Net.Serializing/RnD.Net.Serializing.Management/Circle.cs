
namespace RnD.Net.Serializing.Management
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    internal class Circle
    {
        public double radius;

        [NonSerialized]
        public double area;

        public Circle(double radius)
        {
            this.radius = radius;
            this.area = Math.PI * radius * radius;
        }

        [OnDeserialized]
        void OnRestore(StreamingContext context)
        {
            this.area = Math.PI * radius * radius;
        }

    }
}
