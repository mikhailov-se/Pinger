namespace Pinger.Interfaces
{
    public interface IPinger
    {
        void Ping(string ipOrHostName, int port, int timeout);
    }
}
