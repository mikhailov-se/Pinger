using NUnit.Framework;
using Pinger;
using Pinger.Interfaces;

namespace PingerTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Pinger.Logger logger = new Logger();

            Pinger.Pingers.TcpPinger pinger = new Pinger.Pingers.TcpPinger(logger);

            pinger.Ping("8.8.8.8", 80, 2);


        }
    }
}