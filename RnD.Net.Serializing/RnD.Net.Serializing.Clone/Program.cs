
namespace RnD.Net.Serializing.Clone
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        [Serializable]
        internal sealed class Order { public string Name { get; set; } }

        [Serializable]
        internal sealed class Product { public string Name { get; set; } }

        static List<Order> orders = new List<Order>();
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            var cmd = Console.ReadLine();
            if (cmd.Equals("save", StringComparison.OrdinalIgnoreCase))
            {
                for (int i = 0; i < 10; i++)
                {
                    orders.Add(new Order() { Name = String.Format("order_{0}", i) });
                    products.Add(new Product() { Name = String.Format("product_{0}", i) });
                }
                SaveState();
            }
            else if (cmd.Equals("restore", StringComparison.OrdinalIgnoreCase))
            {
                RestoreState();
                foreach (var ord in orders)
                    Console.WriteLine(ord.Name);

                foreach (var prod in products)
                    Console.WriteLine(prod.Name);
            }
            else Console.WriteLine("nope");
        }

        static object Clone(object obj)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Context = new StreamingContext(StreamingContextStates.Clone);
                formatter.Serialize(stream, obj);

                stream.Position = 0;

                return formatter.Deserialize(stream);
            }
        }

        static void SaveState()
        {
            using (var stream = new FileStream("state.txt", FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, orders);
                formatter.Serialize(stream, products);
            }
        }

        static void RestoreState()
        {
            using (var fileStream = new FileStream("state.txt", FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                orders = formatter.Deserialize(fileStream) as List<Order>;
                products = formatter.Deserialize(fileStream) as List<Product>;
            }
        }
    }
}
