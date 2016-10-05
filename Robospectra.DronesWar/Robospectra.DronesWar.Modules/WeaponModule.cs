
namespace Robospectra.DronesWar.Modules
{
    using Ninject.Modules;
    using Robospectra.DronesWar.Common;

    public class WeaponModule : NinjectModule
    {
        readonly string country;

        public WeaponModule(string country)
        {
            this.country = country;
        }

        public override void Load()
        {
            Bind<IWeapon>().To<M16>()
                .WhenInjectedInto(typeof(Sword))
                .WithConstructorArgument<int>(30)
                .WithConstructorArgument<string>("M16");

            Bind<IWeapon>().To<HellFireRocket>()
                .WhenInjectedInto(typeof(Predator))
                .WithConstructorArgument<int>(4)
                .WithConstructorArgument<string>("Hell-Fire");

            Bind<IWeapon>().To<Kalashnikow>()
               .WhenInjectedInto(typeof(Atlas))
               .WithConstructorArgument<int>(33)
               .WithConstructorArgument<string>("Kalashnikow");
        }
    }
}
