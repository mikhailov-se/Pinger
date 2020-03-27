using Ninject.Modules;
using Pinger.Interfaces;
using Pinger.Pingers;

namespace Pinger.Configs
{
    public class NinjectConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPinger>().To<HttpPinger>().Named("HttpPinger");
            Bind<IPinger>().To<TcpPinger>().Named("TcpPinger");
            Bind<IPinger>().To<IcmpPinger>().Named("IcmpPinger");

            Bind<ILogger>().To<Logger>();

        }

    }
}
