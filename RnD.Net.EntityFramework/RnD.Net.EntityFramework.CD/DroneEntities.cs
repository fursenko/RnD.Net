
namespace RnD.Net.EntityFramework.CD
{
    using System.Data.Entity;

    public partial class DroneEntities : DbContext
    {
        public DroneEntities(): base("name = RobospectraDB") {}

        public IDbSet<Drone> Drones { get; set; }
        public IDbSet<DroneConfiguration> DroneConfigurations { get; set; }
    }
}
