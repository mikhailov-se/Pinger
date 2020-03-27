using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Pinger.Interfaces;

namespace Pinger.Pingers
{
   public class IcmpPinger : IPinger
    {
        private readonly ILogger _logger;

        public IcmpPinger(ILogger logger)
        {
            _logger = logger;
        }

        public void Ping(string ip, int port, int timeout)
        {
            try
            {
                timeout *= 1000;

                var endPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);

                var tsk = socket.ConnectAsync(endPoint);

                if (tsk.Wait(timeout) && socket.Connected)
                    _logger.Log(endPoint.Address + ":" + +port + " Ok");
                else
                    _logger.LogError(endPoint.Address + ":" + +port + "Failed");

                socket.Dispose();
                tsk.Dispose();
            }

            catch (WebException e)
            {
                _logger.LogError(ip + ": " + port + " " + "Failed " + e.Status);
            }
            catch (Exception e)
            {
                _logger.LogError(ip + ": " + port + " " + "Failed " + e.Message);
            }
        }
    }
}
