using System;
using Pinger.Interfaces;

namespace PingerTests
{
    public class TestLogger : ILogger
    {
        public void LogSuccess(string mes)
        {
        }

        public void LogError(string mes)
        {
            throw new Exception();
        }
    }
}