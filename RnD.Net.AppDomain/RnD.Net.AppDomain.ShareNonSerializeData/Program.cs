
namespace RnD.Net.AppDomain.ShareNonSerializeData
{
    using Common;
    using System;
    using System.Reflection;

    class Program
    {
        static AppDomain GetNewDomain()
        {
            return AppDomain.CreateDomain("dm#2");
        }

        static void Main(string[] args)
        {
            try
            {
                var domain = GetNewDomain();
                var crossDomainPoint = domain.CreateInstanceAndUnwrap(Assembly.GetAssembly(typeof(CrossDomainPoint)).FullName, typeof(CrossDomainPoint).FullName) as CrossDomainPoint;
                // We are expecting an serialization exception.
                var nonSerialazableContext = crossDomainPoint.GetNonSerializableContext();
                Console.WriteLine("Is nonSerialazableContext null {0}", nonSerialazableContext == null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
