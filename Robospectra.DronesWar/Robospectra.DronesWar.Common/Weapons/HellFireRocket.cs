
namespace Robospectra.DronesWar.Common
{
    using System;

    public class HellFireRocket : IWeapon
    {
        public HellFireRocket(string name, int amunition)
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

            return new Rocket("Hell Fire Rocket", 20, position);
        }
    }
}
