namespace RMV.DriverExaminer.Service.Interfaces
{
    public interface ICustomLogger<T>
    {
        void Information(string message, params object[] args);
        void Warning(string message, params object[] args);
        
        void Error(string message, params object[] args);
    }
}
