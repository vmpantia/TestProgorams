
namespace Common.Library.Services
{
    public interface ILogger
    {
        void WriteErrorLog(Exception ex);
        void WriteInfoLog(string info);
        void WriteEventLog(string systemName, Exception ex);
    }
}