
namespace Robospectra.DronesWar.Common
{
    public class Atlas : DroneBase
    {
        public Atlas(IWeapon weapon) : base(weapon)
        {
            Country = "USA";
            Name = "Atlas";
        }
    }
}
