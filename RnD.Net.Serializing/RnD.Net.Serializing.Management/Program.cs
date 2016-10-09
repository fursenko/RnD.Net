
namespace RnD.Net.Serializing.Management
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization.Formatters.Soap;

    [Serializable]
    internal class Drone
    {
        int coordinatr;
        public int Coordinate
        {
            get { return coordinatr; }
            set { coordinatr = value; }
        }
    }

    [Serializable]
    internal sealed class Reaper : Drone { }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //TestOptionalField();
                var graph = RestoreAsSoap() as OptionalSerializingObject;
                Console.WriteLine("Coordinate 'x' : {0}", graph.x);
                Console.WriteLine("Coordinate 'y' : {0}", graph.y);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static void Save(Object graph)
        {
            using (var stream = new FileStream("data.txt", FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, graph);
            }
            Console.WriteLine("Object is serialized");
        }

        static void SaveAsSoap(Object graph)
        {
            using (var stream = new FileStream("data.txt", FileMode.Create))
            {
                var formatter = new SoapFormatter();
                formatter.Serialize(stream, graph);
            }
            Console.WriteLine("Object is serialized");
        }

        static object RestoreAsSoap()
        {
            using (var stream = new FileStream("data.txt", FileMode.Open))
            {
                var formatter = new SoapFormatter();
                return formatter.Deserialize(stream);
            }
        }

        static void TestFullControlObject()
        {
            Console.WriteLine("----------- FULL CONTROL SERIALIZING ------------");
            var fullControllObject = new FullControlSerializingObject(2, 2);
            SaveAsSoap(fullControllObject);
            fullControllObject = null;
            Console.WriteLine("Save full control object");
            fullControllObject = RestoreAsSoap() as FullControlSerializingObject;
            Console.WriteLine("Full control object is restored");
            Console.WriteLine("FCO Height: {0}", fullControllObject.high);
            Console.WriteLine("FCO Width: {0}", fullControllObject.width);
        }
        

        static void TestOptionalField()
        {
            Console.WriteLine("----------- OPTINAL FIELD TEST ------------");
            var graph = new OptionalSerializingObject();

            graph.x = 12;
            graph.y = 12;
            //graph.z = 12;

            SaveAsSoap(graph);
        }
    }
}
