
namespace RnD.Net.EntityFramework.DF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    AddData();
                    Console.WriteLine("one drone was added");
                }

                Console.WriteLine("\n");

                var drones = GetDrones();

                foreach (var drone in drones)
                    Console.WriteLine("Drone: [ID: {0}, Name: {1}]", drone.Id, drone.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }    
        }

        static void AddData()
        {
            using (var model = new RobospectraEntities())
            {
                var drone = model.Drones.Create();
                drone.Name = String.Format("Drone_{0}", Guid.NewGuid());

                var configuration = model.DroneConfigurations.Create();
                configuration.Config = "config data";

                drone.DroneConfiguration = configuration;
                model.Drones.Add(drone);
                
                model.SaveChanges();
            }
        }

        static List<Drone> GetDrones()
        {
            using (var model = new RobospectraEntities())
            {
                return model.Drones.ToList();
            }
        } 
    }
}
