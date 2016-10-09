

namespace RnD.Net.Serializing.Surrogate
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Soap;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new SoapFormatter();

                var surogateSelector = new SurrogateSelector();
                surogateSelector.AddSurrogate(typeof(DateTime), formatter.Context, new DateTimeSerializationSurrogate());

                formatter.SurrogateSelector = surogateSelector;

                var time = DateTime.Now;
                formatter.Serialize(stream, time);

                stream.Position = 0;
                Console.WriteLine(new StreamReader(stream).ReadToEnd());

                stream.Position = 0;
                var newTime = (DateTime)formatter.Deserialize(stream);

                Console.WriteLine("Old time: {0}", time);
                Console.WriteLine("New time: {0}", newTime);
            }
        }
    }
}
