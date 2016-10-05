
namespace Robospectra.DronesWar.Modules
{
    using Common;
    using Ninject.Modules;

    public class DroneModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDrone>().To<Predator>();
            Bind<IDrone>().To<Sword>();
            Bind<IDrone>().To<Atlas>();
        }
    }
}
