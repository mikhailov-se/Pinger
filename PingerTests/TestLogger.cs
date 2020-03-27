using System;
using System.Collections.Generic;
using System.Text;
using Pinger.Interfaces;

namespace PingerTests
{
    class TestLogger : ILogger
    {
        public void Log(string mes)
        {
            throw new NotImplementedException();
        }

        public void LogError(string mes)
        {
            throw new NotImplementedException();
        }
    }
}
