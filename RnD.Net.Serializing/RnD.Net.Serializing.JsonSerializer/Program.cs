
namespace RnD.Net.Serializing.JsonSerializer
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;

    [DataContract]
    internal sealed class Drone
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid Id { get; set; }

        public Drone(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return String.Format("ID: {0} / Name: {1}", Id, Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new FileStream("data.xml", FileMode.Create))
            {
                var serializer = new DataContractJsonSerializer(typeof(Drone));
                serializer.WriteObject(stream, new Drone("Gaspar"));
                stream.Position = 0;

                Console.WriteLine(new StreamReader(stream).ReadToEnd());
            }
            
        }
    }
}
