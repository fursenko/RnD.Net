

namespace RnD.Net.AppDomain.Common
{
    using System;
    using System.Reflection;
    using System.Linq;

    public class Proxy: MarshalByRefObject
    {
        public IPlugin GetPlugin(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
            var assembly = Assembly.LoadFrom(path);

            var type = (from tp in assembly.GetTypes() where typeof(IPlugin).IsAssignableFrom(tp) select tp).FirstOrDefault();

            if (type == null)
                throw new ApplicationException("Could not find IPlufin type in loaded assembly");

            return assembly.CreateInstance(type.FullName) as IPlugin;
        }
    }
}
