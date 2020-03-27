using System;
using System.Net;
using System.Net.Sockets;
using Pinger.Interfaces;

namespace Pinger.Pingers
{
    public class TcpPinger : IPinger
    {
        private readonly ILogger _logger;

        public TcpPinger(ILogger logger)
        {
            _logger = logger;
        }


        public void Ping(string hostName, int port, int timeout)
        {
            try
            {
                var client = new TcpClient();
                timeout *= 1000;

                var tsk = IPAddress.TryParse(hostName, out var hostIp)
                    ? client.ConnectAsync(hostIp, port)
                    : client.ConnectAsync(hostName, port);

                if (tsk.Wait(timeout) && client.Connected)
                    _logger.Log(hostName + ":" +  + port + " Ok");
                else
                    _logger.LogError(hostName + ":" + +port + " Failed");

            }

            catch (WebException e)
            {
                _logger.LogError(hostName + ": " + port + " " + " Failed " + e.Response);
            }
            catch (Exception e)
            {
                _logger.LogError(hostName + ": " + port + " " + " Failed " + e.Message);
            }
        }
    }
}
