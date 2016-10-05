namespace Robospectra.DronesWar.Common
{
    public interface IShot
    {
        string Name { get; set; }
        byte[] Destination { get; set; }
        int Damage { get; set; }
    }
}