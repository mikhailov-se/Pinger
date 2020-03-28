namespace Pinger.Interfaces
{
    public interface ILogger
    {
        void LogSuccess(string mes);
        void LogError(string mes);
    }
}