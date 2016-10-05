
namespace Robospectra.DronesWar.App
{
    using Ninject;
    using Robospectra.DronesWar.Common;
    using Robospectra.DronesWar.Modules;
    using System;


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Drones War Units \n");

                using (var kernel = new StandardKernel())
                {
                    kernel.Load(new WeaponModule("USA"));
                    kernel.Load(new DroneModule());

                    var drones = kernel.GetAll<IDrone>();

                    foreach (var drone in drones)
                    {
                        Console.WriteLine("================ {0} ================", drone.Name);
                        Console.WriteLine("Country: {0}", drone.Country);
                        Console.WriteLine("Weapon: {0}", drone.Weapon.Name);
                        Console.WriteLine("Shooting: {0}", drone.Weapon.Shoot(null).Name);
                        Console.WriteLine("\n");
                    }
                }

                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                if(exception.InnerException != null)
                    Console.WriteLine(exception.InnerException.Message);
            }
        }
    }
}
