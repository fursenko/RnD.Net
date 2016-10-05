namespace Robospectra.DronesWar.Common
{
    public interface IWeapon
    {
        IShot Shoot(byte[] position);
        string Name { get; set; }
        int Amunition { get; set; }
    }
}