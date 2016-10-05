
namespace Robospectra.DronesWar.Common
{
    public class Predator : DroneBase
    {
        public Predator(IWeapon weapon) : base(weapon)
        {
            Country = "USA";
            Name = "Predator";
        }
    }
}
