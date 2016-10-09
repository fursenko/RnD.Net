
namespace RnD.Net.Serializing.SoapFormatter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.Serialization.Formatters.Soap;

    [Serializable]
    internal class PasswordStore
    {
        private readonly string password;        

        public PasswordStore()
        {
            this.password = Guid.NewGuid().ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Save(new PasswordStore());
                Console.WriteLine("Password store is saved");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Save(Object graph)
        {
            using (var stream = new FileStream("data.txt", FileMode.Create))
            {
                var formatter = new SoapFormatter();
                formatter.Serialize(stream, graph);
            }
        }
    }
}
