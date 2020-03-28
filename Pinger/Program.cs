using System;
using System.Configuration;
using System.Threading;
using Ninject;
using Pinger.Configs;
using Pinger.Interfaces;

namespace Pinger
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using var timer = new Timer(Ping, null, 0, GetInterval());

            Console.Read();
        }


        private static void Ping(object state)
        {
            var pinger = GetPinger();
            var host = ConfigurationManager.AppSettings.Get("Host");
            var responseTimeout = GetResponseTimeout();
            var port = GetPort();
           
            pinger.Ping(host, port, responseTimeout);
        }


        private static IPinger GetPinger()
        {
            IKernel kernel = new StandardKernel(new NinjectConfigModule());

            var nameProtocol = ConfigurationManager.AppSettings.Get("TypeProtocol");

            Enum.TryParse(nameProtocol, true, out TypeProtocol typeProtocol);

            return typeProtocol switch
            {
                TypeProtocol.Http => kernel.Get<IPinger>("HttpPinger"),
                TypeProtocol.Icmp => kernel.Get<IPinger>("IcmpPinger"),
                TypeProtocol.Tcp => kernel.Get<IPinger>("TcpPinger"),
                _ => null
            };
        }


        private static int GetInterval()
        {
            var interval = ConfigurationManager.AppSettings.Get("PingInterval");
            return Convert.ToInt32(interval) * 1000;
        }

        private static int GetResponseTimeout()
        {
            var responseTimeout = ConfigurationManager.AppSettings.Get("ResponseTimeout");
            return Convert.ToInt32(responseTimeout);
        }

        private static int GetPort()
        {
            var port = ConfigurationManager.AppSettings.Get("Port");
            return int.Parse(port);
        }

    }
}
