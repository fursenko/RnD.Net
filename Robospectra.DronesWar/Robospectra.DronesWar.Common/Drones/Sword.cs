
namespace Robospectra.DronesWar.Common
{
    public class Sword : DroneBase
    {
        public Sword(IWeapon weapon) : base(weapon)
        {
            Country = "Israel";
            Name = "Sword";
        }
    }
}
