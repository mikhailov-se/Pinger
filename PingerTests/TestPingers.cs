using System;
using NUnit.Framework;
using Pinger.Pingers;

namespace PingerTests
{
    public class PingersTests
    {
        [Test]
        public void TcpPingerTest()
        {
            var testLogger = new TestLogger();

            var pinger = new TcpPinger(testLogger);

            Assert.DoesNotThrow(() => { pinger.Ping("8.8.8.8", 443, 2); });
            Assert.DoesNotThrow(() => { pinger.Ping("ya.ru", 443, 2); });

            Assert.Throws<Exception>(() => { pinger.Ping("8.8.8.868271", 443, 2); });
        }


        [Test]
        public void HttpPingerTest()
        {
            var httpPinger = new HttpPinger(new TestLogger());


            Assert.DoesNotThrow(() => { httpPinger.Ping("http://ya.ru", 443, 2); });

            Assert.Throws<Exception>(() => { httpPinger.Ping("WrongUrl", 443, 2); });
        }


        [Test]
        public void IcmpPingerTest()
        {
            var icmpPinger = new IcmpPinger(new TestLogger());


            Assert.DoesNotThrow(() => { icmpPinger.Ping("8.8.8.8", 443, 2); });

            Assert.Throws<Exception>(() => { icmpPinger.Ping("WrongUrl", 443, 2); });

            
        }
    }
}