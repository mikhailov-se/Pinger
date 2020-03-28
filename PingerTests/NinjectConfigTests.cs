using Ninject;
using NUnit.Framework;
using Pinger.Configs;
using Pinger.Interfaces;
using Pinger.Pingers;

namespace PingerTests
{
    internal class NinjectConfigTests
    {
        [Test]
        public void GetIcmpPingerTest()
        {
            IKernel kernel = new StandardKernel(new NinjectConfigModule());

            var icmpPinger = kernel.Get<IPinger>("IcmpPinger");

            Assert.IsInstanceOf<IcmpPinger>(icmpPinger);
        }


        [Test]
        public void GetTcpPingerTest()
        {
            IKernel kernel = new StandardKernel(new NinjectConfigModule());

            var tcpPinger = kernel.Get<IPinger>("TcpPinger");

            Assert.IsInstanceOf<TcpPinger>(tcpPinger);
        }


        [Test]
        public void GetHttpPingerTest()
        {
            IKernel kernel = new StandardKernel(new NinjectConfigModule());

            var httpPinger = kernel.Get<IPinger>("HttpPinger");

            Assert.IsInstanceOf<HttpPinger>(httpPinger);
        }
    }
}
