
namespace Robospectra.DronesWar.Common
{
    public abstract class ShotBase : IShot
    {
        public ShotBase(string name, int damage, byte[] destination)
        {
            Name = name;
            Damage = damage;
            Destination = destination;
        }

        public string Name { get; set; }

        public byte[] Destination { get; set; }

        public int Damage { get; set; }
    }
}
