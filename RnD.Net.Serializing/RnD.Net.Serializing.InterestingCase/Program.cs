
namespace RnD.Net.Serializing.InterestingCase
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable]
    class MyClass
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
        public string PropertyC { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var command = Console.ReadLine();

                if (command.Equals("save", StringComparison.OrdinalIgnoreCase))
                {
                    var state = GetMyClass();
                    Save(state);
                }
                else if (command.Equals("restore", StringComparison.OrdinalIgnoreCase))
                {
                    var state = Restore() as MyClass;
                    Console.WriteLine(state.PropertyA);
                    Console.WriteLine(state.PropertyB);
                    Console.WriteLine(state.PropertyC);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        static void Save(object obj)
        {
            using(var stream = new FileStream("data.myextension", FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
            }
        }

        static object Restore()
        {
            using (var stream = new FileStream("data.myextension", FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(stream);
            }
        }

        static MyClass GetMyClass()
        {
            return new MyClass() { PropertyA = Guid.NewGuid().ToString(), PropertyB = Guid.NewGuid().ToString(), PropertyC = Guid.NewGuid().ToString() };
        }
    }
}
