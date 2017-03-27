
namespace Multithreading.Training.Plinq
{
    using System;
    using System.Linq;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            //GetObsoleteMethods(Assembly.Load((string.Format(@"{0}\System.dll", Directory.GetCurrentDirectory())));
            GetObsoleteMethods(Assembly.Load("System"));
            Console.ReadKey();
        }

        private static void GetObsoleteMethods(Assembly assembly)
        {
            var query =

                from type in assembly.GetExportedTypes().AsParallel()
                from method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)

                let obsoleteTypeAttrubute = typeof(ObsoleteAttribute)

                where Attribute.IsDefined(method, obsoleteTypeAttrubute)

                orderby type.FullName

                let obsoleteObhAtribute = Attribute.GetCustomAttribute(method, obsoleteTypeAttrubute) as ObsoleteAttribute

                select string.Format(@"type={0}\method={1}\message={2}", type.FullName, method.Name, obsoleteObhAtribute.Message);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
