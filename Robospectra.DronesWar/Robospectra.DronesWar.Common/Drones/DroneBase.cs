
namespace Robospectra.DronesWar.Common
{
    public abstract class DroneBase : IDrone
    {
        public DroneBase(IWeapon wepon)
        {
            Weapon = wepon;
            Live = 100;
            Armour = 100;
        }
        public int Live { get; set; }
        public int Armour { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public byte[] Position { get; set; }
        public IWeapon Weapon { get; set; }
    }
}
