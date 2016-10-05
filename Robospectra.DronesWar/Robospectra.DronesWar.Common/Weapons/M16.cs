
namespace Robospectra.DronesWar.Common
{
    using System;
    public class M16 : IWeapon
    {
        public M16(string name, int amunition)
        {
            Name = name;
            Amunition = amunition;
        }

        public string Name { get; set; }
        public int Amunition { get; set; }

        public IShot Shoot(byte[] position)
        {
            if (Amunition <= 0)
                throw new ApplicationException("Amunition bank is empty");

            Amunition--;

            return new Bullet("M16-Bullet", 5, position);
        }
    }
}
