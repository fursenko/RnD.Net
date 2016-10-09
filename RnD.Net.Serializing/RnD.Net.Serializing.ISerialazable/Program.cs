
namespace RnD.Net.Serializing.ISerialazablesd
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Permissions;


    [Serializable]
    internal class DroneBase { protected string name = "BD_Drone"; }

    [Serializable]
    internal class Attlas : DroneBase, ISerializable
    {
        DateTime time = DateTime.UtcNow;
        public Attlas()
        {}

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public Attlas(SerializationInfo serializationInfo, StreamingContext context)
        {
            var baseType = this.GetType().BaseType;
            var memberInfo = FormatterServices.GetSerializableMembers(baseType, context);

            for (int i = 0; i < memberInfo.Length; i++)
            {
                var field = memberInfo[i] as FieldInfo;
                field.SetValue(this, serializationInfo.GetValue(baseType.FullName + "_" + field.Name, field.FieldType));
            }

            this.time = serializationInfo.GetDateTime("time");
        }

        public void GetObjectData(SerializationInfo serializationInfo, StreamingContext context)
        {
            serializationInfo.AddValue("time", this.time);
            var baseType = this.GetType().BaseType;
            var memberInfo = FormatterServices.GetSerializableMembers(baseType, context);

            for (int i = 0; i < memberInfo.Length; i++)
            {
                serializationInfo.AddValue(baseType.FullName + "_" + memberInfo[i].Name, ((FieldInfo)memberInfo[i]).GetValue(this));
            }
        }

        public override string ToString()
        {
            return String.Format("Name: {0} Time: {1}", this.name, this.time);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Serialize
                using (var stream = new FileStream("data.txt", FileMode.Create))
                {
                    var formatter = new BinaryFormatter();
                    var drone = new Attlas();
                    formatter.Serialize(stream, drone);
                }

                Console.WriteLine("Drone is serialized");

                using (var stream = new FileStream("data.txt", FileMode.Open))
                {

                    var formatter = new BinaryFormatter();
                    var drone = formatter.Deserialize(stream) as Attlas;
                    Console.WriteLine(drone.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
        }
    }
}
