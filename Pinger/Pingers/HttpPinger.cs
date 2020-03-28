using System;
using System.Net;
using System.Net.Http;
using Pinger.Interfaces;

namespace Pinger.Pingers
{
    public class HttpPinger : IPinger
    {
        private readonly ILogger _logger;

        public HttpPinger(ILogger logger)
        {
            _logger = logger;
        }

        public void Ping(string hostName, int port, int timeout)
        {
            try
            {
                var client = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(timeout)
                };

                client.GetAsync(hostName).ContinueWith(task =>
                {

                    if (task.Result.IsSuccessStatusCode)
                    {
                        _logger.LogSuccess(hostName + " OK");
                    }
                    else
                    {
                        _logger.LogError(hostName + " Failed");
                    }


                    client.Dispose();
                    task.Dispose();
                });
            }

            catch (WebException e)
            {
                _logger.LogError(hostName + " " + "Failed " + e.Status);
            }
            catch (Exception e)
            {
                _logger.LogError(hostName + " Failed " + e.Message);
            }
        }
    }
}