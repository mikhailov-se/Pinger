namespace Pinger.Interfaces
{
    public interface ILogger
    {
        void Log(string mes);
        void LogError(string mes);
    }
}