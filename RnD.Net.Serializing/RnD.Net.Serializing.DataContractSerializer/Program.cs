
namespace RnD.Net.Serializing.DataContractSerializer
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    internal class Weapon
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Model { get; set; }

        public Weapon(string name, int model)
        {
            Id = Guid.NewGuid();
            Name = name;
            Model = model;
        }
    }

    [DataContract]
    internal sealed class Drone
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid Id { get; set; }

        // [OptionalField]
        public Weapon weapon;

        public Drone(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            this.weapon = new Weapon("M16", 2211);
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
            using (var stream = new FileStream("object.txt", FileMode.Create))
            {
                var serializer = new DataContractSerializer(typeof(Drone));
                serializer.WriteObject(stream, new Drone("Attlas"));
            }

            Console.WriteLine("Object is saved");

            using (var stream = new FileStream("object.txt", FileMode.Open))
            {
                Console.WriteLine(new StreamReader(stream).ReadToEnd());
                var serializer = new DataContractSerializer(typeof(Drone));
                stream.Position = 0;
                var drone = serializer.ReadObject(stream) as Drone;
                if (drone == null) { Console.WriteLine("Drone is not restored"); return; };
                Console.WriteLine(drone.ToString());
            }

            //var serializer = new DataContractSerializer()
        }
    }
}
