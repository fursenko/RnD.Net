

namespace Robospectra.DronesWar.Common
{
    public interface IDrone
    {
        int Live { get; set; }
        int Armour { get; set; }
        string Name { get; set; }
        string Country { get; set; }
        byte[] Position { get; set; }
        IWeapon Weapon { get; set; }
    }
}
