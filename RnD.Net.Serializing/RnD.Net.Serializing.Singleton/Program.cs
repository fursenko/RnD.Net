
namespace RnD.Net.Serializing.Singleton
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;

    class Program
    {
        static void Main(string[] args)
        {
            var refArr = new SingletonRnD[] { SingletonRnD.GetInstance(),
                SingletonRnD.GetInstance(),
                SingletonRnD.GetInstance(),
                SingletonRnD.GetInstance(),
                SingletonRnD.GetInstance(),
                SingletonRnD.GetInstance(),
                SingletonRnD.GetInstance() };

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, refArr);
                Console.WriteLine("object is serialized");

                stream.Position = 0;

                var res = formatter.Deserialize(stream) as SingletonRnD[];

                if (res != null && res.Length != 0)
                {
                    var newCollection = res.ToList().GetEnumerator();
                    var oldCollection = refArr.ToList().GetEnumerator();

                    // check references.
                    while (oldCollection.MoveNext() && newCollection.MoveNext())
                    {
                        Console.WriteLine("Is the same item: {0}", oldCollection.Current.Equals(newCollection.Current));
                    }
                }
            }

        }
    }
}
